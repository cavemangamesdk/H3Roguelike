using MooseEngine;
using MooseEngine.Graphics;
using MooseEngine.SceneManagement;

Engine.Start<SandboxApplication>();

// TODO: Figure out what to do with this class?
public class Input
{
    public Input(IInput inputImpl)
    {
        InputImpl = inputImpl;
    }

    private static IInput? InputImpl { get; set; }

    public static bool IsKeyPressed(Keycode keycode)
    {
        return InputImpl?.IsKeyPressed(keycode) ?? false;
    }
}

class SandboxApplication : ApplicationBase
{
    public SandboxApplication(IWindow window, IRenderer renderer, IGraphicsFactory graphicsFactory, IRenderer2D renderer2D, ISceneFactory sceneFactory, IInput input)
        : base(window)
    {
        Renderer = renderer;
        GraphicsFactory = graphicsFactory;
        Renderer2D = renderer2D;
        SceneFactory = sceneFactory;
        Input = input;
    }

    private IRenderer Renderer { get; }
    private IGraphicsFactory GraphicsFactory { get; }
    private IRenderer2D Renderer2D { get; }
    private ISceneFactory SceneFactory { get; }
    private IInput Input { get; }

    protected override void InitializeApplication()
    {
        new Input(Input);

        //AttachLayer(new GettingStarted_HelloTriangleLayer(Renderer, GraphicsFactory));
        //AttachLayer(new GettingStarted_TexturesLayer(Renderer, GraphicsFactory));
        //AttachLayer(new CameraTestLayer(Window, Renderer, GraphicsFactory));
        //AttachLayer(new Renderer2DTestLayer(Renderer, Renderer2D, GraphicsFactory));
        AttachLayer(new SceneTestLayer(Renderer, Renderer2D, GraphicsFactory, SceneFactory));
    }
}