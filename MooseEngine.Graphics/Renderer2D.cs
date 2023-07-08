namespace MooseEngine.Graphics;

public interface IRenderer2D
{
    void Initialize();

    void BeginScene();
    void EndScene();
}

internal sealed class Renderer2D : IRenderer2D
{
    struct QuadVertex
    {
        System.Numerics.Vector3 Position;
        System.Numerics.Vector4 Color;
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
        public IVertexBuffer<QuadVertex>? QuadVertexBuffer { get; set; }
        public IIndexBuffer? QuadIndexBuffer { get; set; }
        public uint QuadIndexCount { get; set; }

        public QuadVertex[] QuadVertexBufferBase { get; set; }
        public QuadVertex[] QuadVertexBufferPtr { get; set; }
    }

    private static Renderer2DData? Data { get; set; }

    public Renderer2D(IRenderer renderer, IGraphicsFactory graphicsFactory)
    {
        Renderer = renderer;
        GraphicsFactory = graphicsFactory;
    }

    private IRenderer Renderer { get; }
    private IGraphicsFactory GraphicsFactory { get; }

    public void Initialize()
    {
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

        var shader = GraphicsFactory.CreateShader("");
        var bufferLayout = new BufferLayout(new List<BufferElement>
        {
            new BufferElement("POSITION", ShaderDataType.Float3),
            new BufferElement("COLOR", ShaderDataType.Float3)
        });
        Data.QuadPipeline = GraphicsFactory.CreatePipeline(shader, bufferLayout);

        Data.QuadVertexBufferBase = new QuadVertex[Renderer2DCapabilities.MaxVertices];

        Data.QuadVertexBuffer = GraphicsFactory.CreateVertexBuffer(Data.QuadVertexBufferBase, Renderer2DCapabilities.MaxVertices);
    }

    public void BeginScene()
    {
        StartBatch();
    }

    private void StartBatch()
    {
        if (Data == default)
        {
            throw new InvalidOperationException();
        }

        Data.QuadIndexCount = 0;
        Data.QuadVertexBufferPtr = Data.QuadVertexBufferBase;
    }

    public void EndScene()
    {
        Flush();
    }

    private void Flush()
    {
        Data?.QuadVertexBuffer?.SetData(Data.QuadVertexBufferBase, 0);

        Renderer.DrawGeometry(Data?.QuadPipeline, Data?.QuadVertexBuffer, Data?.QuadIndexBuffer, (int)(Data?.QuadIndexCount ?? 0));
    }
}
