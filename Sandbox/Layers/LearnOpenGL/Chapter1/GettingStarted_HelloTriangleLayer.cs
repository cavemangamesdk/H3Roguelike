using MooseEngine;
using MooseEngine.Graphics;

class GettingStarted_HelloTriangleLayer : LayerBase
{
    public GettingStarted_HelloTriangleLayer(IRenderer renderer, IGraphicsFactory graphicsFactory) 
        : base("LearnOpenGL - GettingStarted-HelloTriangle")
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

    public override void OnAttach()
    {
        var shader = GraphicsFactory.CreateShader();

        var bufferLayout = new BufferLayout(new List<BufferElement>
        {
            new BufferElement("aPos", ShaderDataType.Float3)
        });
        Pipeline = GraphicsFactory.CreatePipeline(shader, bufferLayout);

        var vertices = new float[4 * 3] {
             0.5f,  0.5f, 0.0f,  // top right
             0.5f, -0.5f, 0.0f,  // bottom right
            -0.5f, -0.5f, 0.0f,  // bottom left
            -0.5f,  0.5f, 0.0f   // top left 
        };

        //var vertices = new float[3 * 3] {
        //    -0.5f, -0.5f, 0.0f,
        //     0.5f, -0.5f, 0.0f,
        //     0.0f,  0.5f, 0.0f
        //};

        VertexBuffer = GraphicsFactory.CreateVertexBuffer(vertices);

        var indices = new uint[] {  // note that we start from 0!
            0, 1, 3,   // first triangle
            1, 2, 3    // second triangle
        };
        IndexBuffer = GraphicsFactory.CreateIndexBuffer(indices);
    }

    public override void OnDetach()
    {
    }

    public override void Update(float deltaTime)
    {
        Renderer.Clear();

        Renderer.DrawGeometry(Pipeline, VertexBuffer, IndexBuffer);
    }
}