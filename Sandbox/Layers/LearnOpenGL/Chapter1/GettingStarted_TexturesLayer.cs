using MooseEngine;
using MooseEngine.Graphics;

class GettingStarted_TexturesLayer : LayerBase
{
    public GettingStarted_TexturesLayer(IRenderer renderer, IGraphicsFactory graphicsFactory)
        : base("LearnOpenGL - GettingStarted-Textures")
    {
        Renderer = renderer;
        GraphicsFactory = graphicsFactory;
    }

    private IRenderer Renderer { get; }
    private IGraphicsFactory GraphicsFactory { get; }

    // Runtime
    private IPipeline? Pipeline { get; set; }
    private IVertexBuffer? VertexBuffer { get; set; }
    private IIndexBuffer? IndexBuffer { get; set; }
    private ITexture2D? Texture1 { get; set; }
    private ITexture2D? Texture2 { get; set; }

    public override void OnAttach()
    {
        var shader = GraphicsFactory.CreateShader("Assets/Shaders/LearnOpenGL/Chapter1/GettingStarted_MultipleTextures.shaderfile");

        var bufferLayout = new BufferLayout(new List<BufferElement>
        {
            new BufferElement("POSITION", ShaderDataType.Float3),
            new BufferElement("COLOR", ShaderDataType.Float3),
            new BufferElement("TEXCOORD", ShaderDataType.Float2)
        });
        Pipeline = GraphicsFactory.CreatePipeline(shader, bufferLayout);

        //var vertices = new float[4 * (3 + 3 + 2)] {
        //    // Position             // Colors           // TexCoord
        //     0.5f,  0.5f, 0.0f,     1.0f, 0.0f, 0.0f,   1.0f, 1.0f,  // top right
        //     0.5f, -0.5f, 0.0f,     0.0f, 1.0f, 0.0f,   1.0f, 0.0f,  // bottom right
        //    -0.5f, -0.5f, 0.0f,     0.0f, 0.0f, 1.0f,   0.0f, 0.0f,  // bottom left
        //    -0.5f,  0.5f, 0.0f,     1.0f, 1.0f, 0.0f,   0.0f, 1.0f   // top left 
        //};

        var vertices = new float[4 * (3 + 3 + 2)] {
            // Position             // Colors           // TexCoord
             0.5f,  0.5f, 0.0f,     1.0f, 1.0f, 1.0f,   1.0f, 1.0f,  // top right
             0.5f, -0.5f, 0.0f,     1.0f, 1.0f, 1.0f,   1.0f, 0.0f,  // bottom right
            -0.5f, -0.5f, 0.0f,     1.0f, 1.0f, 1.0f,   0.0f, 0.0f,  // bottom left
            -0.5f,  0.5f, 0.0f,     1.0f, 1.0f, 1.0f,   0.0f, 1.0f   // top left 
        };

        VertexBuffer = GraphicsFactory.CreateVertexBuffer(vertices);

        var indices = new uint[] {  // note that we start from 0!
            0, 1, 3,   // first triangle
            1, 2, 3    // second triangle
        };
        IndexBuffer = GraphicsFactory.CreateIndexBuffer(indices);

        Texture1 = GraphicsFactory.CreateTexture2D("Assets/Textures/container.jpg");
        Texture2 = GraphicsFactory.CreateTexture2D("Assets/Textures/awesomeface.png");

        shader.Bind();
        shader.SetInt("texture1", 0);
        shader.SetInt("texture2", 1);
    }

    public override void OnDetach()
    {
    }

    public override void Update(float deltaTime)
    {
        Renderer.Clear();

        Texture1?.Bind();
        Texture2?.Bind(1);
        Renderer.DrawGeometry(Pipeline, VertexBuffer, IndexBuffer);
    }
}
