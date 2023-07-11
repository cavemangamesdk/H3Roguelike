using MooseEngine;
using MooseEngine.ECS.Components;
using MooseEngine.Events;
using MooseEngine.Graphics;
using MooseEngine.Mathematics.Vectors;
using MooseEngine.SceneManagement;

class SceneTestLayer : LayerBase
{
    public SceneTestLayer(IRenderer renderer, IRenderer2D renderer2D, IGraphicsFactory graphicsFactory, ISceneFactory sceneFactory)
        : base("Scene Test Layer")
    {
        Renderer = renderer;
        Renderer2D = renderer2D;
        GraphicsFactory = graphicsFactory;
        SceneFactory = sceneFactory;
    }

    private IRenderer Renderer { get; }
    private IRenderer2D Renderer2D { get; }
    public IGraphicsFactory GraphicsFactory { get; }
    private ISceneFactory SceneFactory { get; }

    // Runtime
    private IScene? Scene { get; set; }

    public override void OnAttach()
    {
        Renderer2D.Initialize();

        Scene = SceneFactory.CreateScene();

        var cameraEntity = Scene.Create("Camera");
        var cameraTransform = cameraEntity.GetComponent<Transform>();
        var camPos = cameraTransform.Position;
        camPos.X = 2.0f;
        cameraTransform.Position = camPos;

        var cameraScript = cameraEntity.AddComponent<Script>();
        cameraScript.AttachScriptReference<CameraControllerScriptBehaviour>();

        var camera = cameraEntity.AddComponent<Camera>();
        camera.SceneCamera.SetViewport(1024, 768);
        camera.SceneCamera.SetOrthographic(5.0f, -1.0f, 1.0f);

        var spriteEntity = Scene.Create();
        var sr = spriteEntity.AddComponent<SpriteRenderer>();
        sr.Color = new Vector4(0.2f, 0.8f, 0.4f, 1.0f);

        var texturedEntity = Scene.Create();
        var t = texturedEntity.GetComponent<Transform>();
        var pos = t.Position;
        pos.X = 2.0f;
        t.Position = pos;

        var spriteRenderer = texturedEntity.AddComponent<SpriteRenderer>();
        spriteRenderer.Sprite = GraphicsFactory.CreateTexture2D("Assets/Textures/container.jpg");
        spriteRenderer.Color = new Vector4(0.2f, 0.4f, 0.8f, 1.0f);

        Scene?.OnRuntimeStart();
    }

    public override void OnDetach()
    {
        Scene?.OnRuntimeStop();
    }

    public override void Update(float deltaTime)
    {
        Renderer.Clear();

        Scene?.OnRuntimeUpdate(deltaTime);
    }

    public override void OnEvent(EventBase e)
    {
        var dispatcher = new EventDispatcher(e);
        dispatcher.Dispatch<WindowResizeEvent>(OnWindowResizeEventFunc);
    }

    private bool OnWindowResizeEventFunc(WindowResizeEvent e)
    {
        Renderer.SetViewport(e.Width, e.Height);
        Scene?.SetViewport(e.Width, e.Height);

        return true;
    }
}
