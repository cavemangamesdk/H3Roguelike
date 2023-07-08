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
        //AttachLayer(new GettingStarted_HelloTriangleLayer(Renderer, GraphicsFactory));
        AttachLayer(new GettingStarted_TexturesLayer());
    }
}

class GettingStarted_TexturesLayer : LayerBase
{
    public GettingStarted_TexturesLayer()
        : base("LearnOpenGL - GettingStarted-Textures")
    {
    }

    public override void OnAttach()
    {
    }

    public override void OnDetach()
    {
    }

    public override void Update(float deltaTime)
    {
    }
}
