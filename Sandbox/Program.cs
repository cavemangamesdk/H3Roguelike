using MooseEngine;
using MooseEngine.Graphics;

Engine.Start<SandboxApplication>();

class SandboxApplication : ApplicationBase
{
    public SandboxApplication(IWindow window, IRenderer renderer, IGraphicsFactory graphicsFactory)
        : base(window)
    {
        Renderer = renderer;
        GraphicsFactory = graphicsFactory;
    }

    private IRenderer Renderer { get; }
    private IGraphicsFactory GraphicsFactory { get; }

    protected override void InitializeApplication()
    {
        AttachLayer(new SandboxLayer(Renderer, GraphicsFactory));
    }
}

class SandboxLayer : LayerBase
{
    public SandboxLayer(IRenderer renderer, IGraphicsFactory graphicsFactory) 
        : base("Sandbox Layer")
    {
        Renderer = renderer;
        GraphicsFactory = graphicsFactory;
    }

    private IRenderer Renderer { get; }
    private IGraphicsFactory GraphicsFactory { get; }

    // Runtime
    private IPipeline? Pipeline { get; set; }
    private IVertexBuffer? VertexBuffer { get; set; }

    public override void OnAttach()
    {
        var shader = GraphicsFactory.CreateShader();

        var bufferLayout = new BufferLayout(new List<BufferElement>
        {
            new BufferElement("aPos", ShaderDataType.Float3)
        });
        Pipeline = GraphicsFactory.CreatePipeline(shader, bufferLayout);
        VertexBuffer = GraphicsFactory.CreateVertexBuffer();
    }

    public override void OnDetach()
    {
    }

    public override void Update(float deltaTime)
    {
        Renderer.Clear();

        Renderer.DrawGeometry(Pipeline, VertexBuffer);
    }
}