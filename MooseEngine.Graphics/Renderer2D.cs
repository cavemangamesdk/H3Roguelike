using MooseEngine.Graphics.Enumerations;
using MooseEngine.Mathematics;
using MooseEngine.Mathematics.Matrixes;
using MooseEngine.Mathematics.Vectors;

namespace MooseEngine.Graphics;

public interface IRenderer2D
{
    void Initialize();

    void BeginScene(ICamera? camera);
    void EndScene();

    void DrawQuad(Vector2 position, Vector2 size, Vector4 color);
    void DrawQuad(Vector3 position, Vector2 size, Vector4 color);
    void DrawQuad(Matrix4 transform, Vector4 color);
}

internal sealed partial class Renderer2D : IRenderer2D
{
    struct QuadVertex
    {
        public Vector3 Position;
        public Vector4 Color;
    };

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
            internal Matrix4 ProjectionMatrix;
            internal Matrix4 ViewMatrix;
        };
        public CameraDataStruct CameraData;
        public IUniformBuffer? CameraUniformBuffer { get; set; }
    }

    private static Renderer2DData? Data { get; set; }
    private static int QuadVertexSize;
    private static int CameraDataStructSize;

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
        CameraDataStructSize = System.Runtime.CompilerServices.Unsafe.SizeOf<Renderer2DData.CameraDataStruct>();

        Data = new Renderer2DData();

        var indices = new uint[Capabilities.MaxIndices];
        var offset = default(uint);
        for (int i = 0; i < Capabilities.MaxIndices; i += 6)
        {
            indices[i + 0] = offset + 0;
            indices[i + 1] = offset + 1;
            indices[i + 2] = offset + 2;

            indices[i + 3] = offset + 2;
            indices[i + 4] = offset + 3;
            indices[i + 5] = offset + 0;

            offset += 4;
        }

        Data.QuadIndexBuffer = GraphicsFactory.CreateIndexBuffer(indices, Capabilities.MaxIndices);

        var shader = GraphicsFactory.CreateShader("Assets/Shaders/Renderer2D.glsl");
        var bufferLayout = new BufferLayout(new List<BufferElement>
        {
            new BufferElement("POSITION", ShaderDataType.Float3),
            new BufferElement("COLOR", ShaderDataType.Float4)
        });
        Data.QuadPipeline = GraphicsFactory.CreatePipeline(shader, bufferLayout);

        Data.QuadVertexBufferArr = new QuadVertex[Capabilities.MaxVertices];

        Data.QuadVertexBuffer = GraphicsFactory.CreateVertexBuffer(Capabilities.MaxVertices * QuadVertexSize, BufferUsage.DynamicDraw);

        Data.CameraUniformBuffer = GraphicsFactory.CreateUniformBuffer(128, 0);

        Data.QuadVertexPositions[0] = new Vector4(-0.5f, -0.5f, 0.0f, 1.0f);
        Data.QuadVertexPositions[1] = new Vector4(0.5f, -0.5f, 0.0f, 1.0f);
        Data.QuadVertexPositions[2] = new Vector4(0.5f, 0.5f, 0.0f, 1.0f);
        Data.QuadVertexPositions[3] = new Vector4(-0.5f, 0.5f, 0.0f, 1.0f);
    }

    public void BeginScene(ICamera? camera)
    {
        Data.CameraData.ProjectionMatrix = camera?.Projection ?? Matrix4.Identity;
        Data.CameraData.ViewMatrix = camera?.View ?? Matrix4.Identity;

        Data?.CameraUniformBuffer?.SetData(Data?.CameraData ?? default!, CameraDataStructSize);

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

        Array.Clear(Data.QuadVertexBufferArr, 0, Capabilities.MaxVertices);
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

    public void DrawQuad(Vector2 position, Vector2 size, Vector4 color) => DrawQuad(new Vector3(position.X, position.Y, 0.0f), size, color);
    public void DrawQuad(Vector3 position, Vector2 size, Vector4 color)
    {
        var transform = Matrix4.Translate(new Vector3(position.X, position.Y, position.Z)) * Matrix4.Scale(new Vector3(size.X, size.Y, 1.0f));
        DrawQuad(transform, color);
    }

    public void DrawQuad(Matrix4 transform, Vector4 color)
    {
        if (Data?.QuadIndexCount >= Capabilities.MaxIndices)
        {
            NextBatch();
        }

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
