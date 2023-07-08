using MooseEngine.Graphics.Enumerations;
using MooseEngine.Mathematics;
using MooseEngine.Mathematics.Matrixes;
using MooseEngine.Mathematics.Vectors;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MooseEngine.Graphics;

public interface IRenderer2D
{
    void Initialize();

    void BeginScene(ICamera? camera);
    void EndScene();

    void DrawQuad(Vector2 position, Vector2 size, Vector4 color);
}

internal sealed class Renderer2D : IRenderer2D
{
    struct QuadVertex
    {
        public Vector3 Position;
        public Vector4 Color;
    };

    private class Renderer2DCapabilities
    {
        public const int MaxQuads = 200000;
        public const int MaxVertices = MaxQuads * 4;
        public const int MaxIndices = MaxQuads * 6;
        public const int MaxTextureSlots = 32; // 32 is the max for OpenGL, 16 for DirectX
    }

    private class Renderer2DData
    {
        // Quad
        public IPipeline? QuadPipeline { get; set; }
        public IVertexBuffer? QuadVertexBuffer { get; set; }
        public IIndexBuffer? QuadIndexBuffer { get; set; }
        public uint QuadIndexCount { get; set; }
        public int QuadVertexCount { get; set; }
        public QuadVertex[] QuadVertexBufferArr { get; set; }

        public int QuadVertexBufferCount;

        public Vector4[] QuadVertexPositions = new Vector4[4];

        internal struct CameraDataStruct
        {
            public Matrix4 ProjectionMatrix;
            public Matrix4 ViewMatrix;
        };
        public CameraDataStruct CameraData;
        public IUniformBuffer? CameraUniformBuffer { get; set; }
    }

    private static Renderer2DData? Data { get; set; }
    private static int QuadVertexSize;

    public Renderer2D(IRenderer renderer, IGraphicsFactory graphicsFactory)
    {
        Renderer = renderer;
        GraphicsFactory = graphicsFactory;
    }

    private IRenderer Renderer { get; }
    private IGraphicsFactory GraphicsFactory { get; }

    public void Initialize()
    {
        QuadVertexSize = System.Runtime.CompilerServices.Unsafe.SizeOf<QuadVertex>();

        Data = new Renderer2DData();

        var indices = new uint[Renderer2DCapabilities.MaxIndices];
        var offset = default(uint);
        for (int i = 0; i < Renderer2DCapabilities.MaxIndices; i += 6)
        {
            indices[i + 0] = offset + 0;
            indices[i + 1] = offset + 1;
            indices[i + 2] = offset + 2;

            indices[i + 3] = offset + 2;
            indices[i + 4] = offset + 3;
            indices[i + 5] = offset + 0;

            offset += 4;
        }

        Data.QuadIndexBuffer = GraphicsFactory.CreateIndexBuffer(indices, Renderer2DCapabilities.MaxIndices);

        var shader = GraphicsFactory.CreateShader("Assets/Shaders/Renderer2D.glsl");
        var bufferLayout = new BufferLayout(new List<BufferElement>
        {
            new BufferElement("POSITION", ShaderDataType.Float3),
            new BufferElement("COLOR", ShaderDataType.Float4)
        });
        Data.QuadPipeline = GraphicsFactory.CreatePipeline(shader, bufferLayout);

        Data.QuadVertexBufferArr = new QuadVertex[Renderer2DCapabilities.MaxVertices];

        Data.QuadVertexBuffer = GraphicsFactory.CreateVertexBuffer(Renderer2DCapabilities.MaxVertices * QuadVertexSize, BufferUsage.DynamicDraw);

        Data.CameraUniformBuffer = GraphicsFactory.CreateUniformBuffer(128, 0);

        Data.QuadVertexPositions[0] = new Vector4(-0.5f, -0.5f, 0.0f, 1.0f);
        Data.QuadVertexPositions[1] = new Vector4( 0.5f, -0.5f, 0.0f, 1.0f);
        Data.QuadVertexPositions[2] = new Vector4( 0.5f,  0.5f, 0.0f, 1.0f);
        Data.QuadVertexPositions[3] = new Vector4(-0.5f,  0.5f, 0.0f, 1.0f);
    }

    public void BeginScene(ICamera? camera)
    {
        Data?.CameraUniformBuffer?.SetData(camera.Projection.ToFloatArray(), 16 * sizeof(float));
        Data?.CameraUniformBuffer?.SetData(camera.View.ToFloatArray(), 16 * sizeof(float), 16 * sizeof(float));

        StartBatch();
    }

    private void StartBatch()
    {
        if (Data == default)
        {
            throw new InvalidOperationException();
        }

        Data.QuadIndexCount = 0;
        Data.QuadVertexCount = 0;

        Array.Clear(Data.QuadVertexBufferArr, 0, Renderer2DCapabilities.MaxVertices);
    }

    public void EndScene()
    {
        Flush();
    }

    private void Flush()
    {
        var size = Data.QuadVertexCount * QuadVertexSize;
        Data?.QuadVertexBuffer?.SetData(Data.QuadVertexBufferArr, size);

        Renderer.DrawGeometry(Data?.QuadPipeline, Data?.QuadVertexBuffer, Data?.QuadIndexBuffer, (int)(Data?.QuadIndexCount ?? 0));
    }

    public void DrawQuad(Vector2 position, Vector2 size, Vector4 color)
    {
        if(Data?.QuadIndexCount >= Renderer2DCapabilities.MaxIndices)
        {
            NextBatch();
        }

        var transform = Matrix4.Translate(new Vector3(position.X, position.Y, 0.0f)) * Matrix4.Scale(new Vector3(size.X, size.Y, 0.0f));

        for (int i = 0; i < 4; i++)
        {
            
            Data!.QuadVertexBufferArr[Data.QuadVertexCount + i].Position = transform * Data.QuadVertexPositions[i];
            Data!.QuadVertexBufferArr[Data.QuadVertexCount + i].Color = color;
        }

        Data.QuadVertexCount += 4;
        Data.QuadIndexCount += 6;
    }

    private void NextBatch()
    {
        Flush();
        StartBatch();
    }
}
