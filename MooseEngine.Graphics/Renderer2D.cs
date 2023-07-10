using MooseEngine.Graphics.Enumerations;
using MooseEngine.Graphics.OpenGL;
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

    void DrawQuad(Vector2 position, Vector2 scale, Vector4 color);
    void DrawQuad(Vector3 position, Vector2 scale, Vector4 color);
    void DrawQuad(Matrix4 transform, Vector4 color);

    void DrawQuad(Vector2 position, Vector2 scale, ITexture2D texture, Vector4 tintColor, float tilingFactor = 1.0f);
    void DrawQuad(Vector3 position, Vector2 scale, ITexture2D texture, Vector4 tintColor, float tilingFactor = 1.0f);
    void DrawQuad(Matrix4 transform, ITexture2D texture, Vector4 tintColor, float tilingFactor = 1.0f);
}

internal sealed partial class Renderer2D : IRenderer2D
{
    struct QuadVertex
    {
        public Vector3 Position;
        public Vector4 Color;
        public Vector2 TexCoord;
        public float TextureIndex;
        public float TilingFactor;
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
        public Vector2[] QuadTexCoords = new Vector2[4];

        public ITexture2D? WhiteTexture { get; set; }

        public ITexture2D[] TextureSlots = Array.Empty<ITexture2D>();
        public uint TextureSlotIndex;

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
            new BufferElement("COLOR", ShaderDataType.Float4),
            new BufferElement("TEXCOORD", ShaderDataType.Float2),
            new BufferElement("TEXTURE", ShaderDataType.Float),
            new BufferElement("TILING_FACTOR", ShaderDataType.Float)
        });
        Data.QuadPipeline = GraphicsFactory.CreatePipeline(shader, bufferLayout);

        Data.QuadVertexBufferArr = new QuadVertex[Capabilities.MaxVertices];

        Data.QuadVertexBuffer = GraphicsFactory.CreateVertexBuffer(Capabilities.MaxVertices * QuadVertexSize, BufferUsage.DynamicDraw);

        Data.CameraUniformBuffer = GraphicsFactory.CreateUniformBuffer(128, 0);

        Data.WhiteTexture = GraphicsFactory.CreateTexture2D(1, 1);
        var whiteTextureDataHandle = ((uint)0xFFFFFFFF).GetMemoryAddress();
        Data.WhiteTexture.SetData(whiteTextureDataHandle.AddrOfPinnedObject(), sizeof(uint));
        whiteTextureDataHandle.Free();

        Data.TextureSlots = new ITexture2D[Capabilities.MaxTextureSlots];
        Data.TextureSlotIndex = 1; // 0 = white texture
        Data.TextureSlots[0] = Data.WhiteTexture;

        int[] samplers = new int[Capabilities.MaxTextureSlots];
        for (int i = 0; i < Capabilities.MaxTextureSlots; i++)
        {
            samplers[i] = i;
        }

        Data.QuadVertexPositions[0] = new Vector4(-0.5f, -0.5f, 0.0f, 1.0f);
        Data.QuadVertexPositions[1] = new Vector4(0.5f, -0.5f, 0.0f, 1.0f);
        Data.QuadVertexPositions[2] = new Vector4(0.5f, 0.5f, 0.0f, 1.0f);
        Data.QuadVertexPositions[3] = new Vector4(-0.5f, 0.5f, 0.0f, 1.0f);

        Data.QuadTexCoords[0] = new Vector2(0.0f, 0.0f);
        Data.QuadTexCoords[1] = new Vector2(1.0f, 0.0f);
        Data.QuadTexCoords[2] = new Vector2(1.0f, 1.0f);
        Data.QuadTexCoords[3] = new Vector2(0.0f, 1.0f);
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

        Array.Clear(Data.QuadVertexBufferArr, 0, Data.QuadVertexBufferArr.Length);
    }

    public void EndScene()
    {
        Flush();
    }

    private void Flush()
    {
        var size = Data.QuadVertexCount * QuadVertexSize;
        Data?.QuadVertexBuffer?.SetData(Data.QuadVertexBufferArr, size);

        for (uint i = 0; i < Data.TextureSlotIndex; i++)
        {
            Data.TextureSlots[i].Bind(i);
        }

        Renderer.DrawGeometry(Data?.QuadPipeline, Data?.QuadVertexBuffer, Data?.QuadIndexBuffer, (int)Data.QuadIndexCount);
    }

    public void DrawQuad(Vector2 position, Vector2 scale, Vector4 color) => DrawQuad(new Vector3(position.X, position.Y, 0.0f), scale, color);
    public void DrawQuad(Vector3 position, Vector2 scale, Vector4 color)
    {
        var transform = Matrix4.Translate(position) * Matrix4.Scale(new Vector3(scale.X, scale.Y, 1.0f));
        DrawQuad(transform, color);
    }

    public void DrawQuad(Matrix4 transform, Vector4 color)
    {
        const float textureIndex = 0.0f;
        const float tilingFactor = 1.0f;

        if (Data?.QuadIndexCount >= Capabilities.MaxIndices)
        {
            NextBatch();
        }

        for (int i = 0; i < 4; i++)
        {
            // TODO: Figure out why transform doesn't contain Translation/Position ?
            Data!.QuadVertexBufferArr[Data.QuadVertexCount + i].Position = transform.Translation + (transform * Data.QuadVertexPositions[i]);
            Data!.QuadVertexBufferArr[Data.QuadVertexCount + i].Color = color;
            Data!.QuadVertexBufferArr[Data.QuadVertexCount + i].TexCoord = Data.QuadTexCoords[i];
            Data!.QuadVertexBufferArr[Data.QuadVertexCount + i].TextureIndex = textureIndex;
            Data!.QuadVertexBufferArr[Data.QuadVertexCount + i].TilingFactor = tilingFactor;
        }

        Data.QuadVertexCount += 4;
        Data.QuadIndexCount += 6;
    }

    public void DrawQuad(Vector2 position, Vector2 scale, ITexture2D texture, Vector4 tintColor, float tilingFactor) => DrawQuad(new Vector3(position.X, position.Y, 0.0f), scale, texture, tintColor, tilingFactor);
    public void DrawQuad(Vector3 position, Vector2 scale, ITexture2D texture, Vector4 tintColor, float tilingFactor)
    {
        var transform = Matrix4.Scale(new Vector3(scale.X, scale.Y, 1.0f)) * Matrix4.Translate(position);
        DrawQuad(transform, texture, tintColor, tilingFactor);
    }

    public void DrawQuad(Matrix4 transform, ITexture2D texture, Vector4 tintColor, float tilingFactor)
    {
        if (Data?.QuadIndexCount >= Capabilities.MaxIndices)
        {
            NextBatch();
        }

        float textureIndex = 0.0f;
        if (texture != null)
        {
            for (int i = 1; i < Data.TextureSlotIndex; i++)
            {
                if (Data.TextureSlots[i] == texture)
                {
                    textureIndex = (float)i;
                    break;
                }
            }
            if (textureIndex == 0.0f)
            {
                textureIndex = (float)Data.TextureSlotIndex;
                Data.TextureSlots[Data.TextureSlotIndex] = texture;
                Data.TextureSlotIndex++;
            }
        }

        for (int i = 0; i < 4; i++)
        {
            // TODO: Figure out why transform doesn't contain Translation/Position ?
            Data!.QuadVertexBufferArr[Data.QuadVertexCount + i].Position = transform.Translation + (transform * Data.QuadVertexPositions[i]);
            Data!.QuadVertexBufferArr[Data.QuadVertexCount + i].Color = tintColor;
            Data!.QuadVertexBufferArr[Data.QuadVertexCount + i].TexCoord = Data.QuadTexCoords[i];
            Data!.QuadVertexBufferArr[Data.QuadVertexCount + i].TextureIndex = textureIndex;
            Data!.QuadVertexBufferArr[Data.QuadVertexCount + i].TilingFactor = tilingFactor;
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
