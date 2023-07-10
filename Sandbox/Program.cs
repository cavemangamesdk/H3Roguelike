using MooseEngine;
using MooseEngine.ECS.Components;
using MooseEngine.ECS.Entities;
using MooseEngine.ECS.Systems;
using MooseEngine.Graphics;
using MooseEngine.Mathematics.Matrixes;
using MooseEngine.Mathematics.Vectors;
using System.Collections.ObjectModel;

Engine.Start<SandboxApplication>();

class SandboxApplication : ApplicationBase
{
    public SandboxApplication(IWindow window, IRenderer renderer, IGraphicsFactory graphicsFactory, IRenderer2D renderer2D, IEntityFactory entityFactory, IRenderer2DSystem renderingSystem)
        : base(window)
    {
        Renderer = renderer;
        GraphicsFactory = graphicsFactory;
        Renderer2D = renderer2D;
        EntityFactory = entityFactory;
        RenderingSystem = renderingSystem;
    }

    private IRenderer Renderer { get; }
    private IGraphicsFactory GraphicsFactory { get; }
    private IRenderer2D Renderer2D { get; }
    private IEntityFactory EntityFactory { get; }
    private IRenderer2DSystem RenderingSystem { get; }

    protected override void InitializeApplication()
    {
        //AttachLayer(new GettingStarted_HelloTriangleLayer(Renderer, GraphicsFactory));
        //AttachLayer(new GettingStarted_TexturesLayer(Renderer, GraphicsFactory));
        //AttachLayer(new CameraTestLayer(Window, Renderer, GraphicsFactory));
        //AttachLayer(new Renderer2DTestLayer(Renderer, Renderer2D, GraphicsFactory));
        AttachLayer(new SceneTestLayer(Renderer, Renderer2D, GraphicsFactory, EntityFactory, RenderingSystem));
    }
}

class SceneTestLayer : LayerBase
{
    public SceneTestLayer(IRenderer renderer, IRenderer2D renderer2D, IGraphicsFactory graphicsFactory, IEntityFactory entityFactory, IRenderer2DSystem renderingSystem)
        : base("Scene Test Layer")
    {
        Renderer = renderer;
        Renderer2D = renderer2D;
        GraphicsFactory = graphicsFactory;
        EntityFactory = entityFactory;
        Renderer2DSystem = renderingSystem;
    }

    private IRenderer Renderer { get; }
    private IRenderer2D Renderer2D { get; }
    public IGraphicsFactory GraphicsFactory { get; }
    private IEntityFactory EntityFactory { get; }
    private IRenderer2DSystem Renderer2DSystem { get; }

    // Runtime
    private IList<IEntity> Entities { get; set; } = new List<IEntity>();

    public override void OnAttach()
    {
        Renderer2D.Initialize();

        var cameraEntity = EntityFactory.Create("Camera");
        Entities.Add(cameraEntity);

        var cameraTransform = cameraEntity.AddComponent<Transform>();
        var camPos = cameraTransform.Position;
        camPos.X = 2.0f;
        cameraTransform.Position = camPos;

        var camera = cameraEntity.AddComponent<Camera>();
        camera.SceneCamera.SetViewport(1024, 768);
        camera.SceneCamera.SetOrthographic(5.0f, -1.0f, 1.0f);

        var spriteEntity = EntityFactory.Create();
        Entities.Add(spriteEntity);

        spriteEntity.AddComponent<Transform>();
        var sr = spriteEntity.AddComponent<SpriteRenderer>();
        sr.Color = new Vector4(0.2f, 0.8f, 0.4f, 1.0f);

        var texturedEntity = EntityFactory.Create();
        Entities.Add(texturedEntity);

        var t = texturedEntity.AddComponent<Transform>();
        var pos = t.Position;
        pos.X = 2.0f;
        t.Position = pos;

        var spriteRenderer = texturedEntity.AddComponent<SpriteRenderer>();
        spriteRenderer.Sprite = GraphicsFactory.CreateTexture2D("Assets/Textures/container.jpg");
        spriteRenderer.Color = new Vector4(0.2f, 0.4f, 0.8f, 1.0f);
    }

    public override void OnDetach()
    {
    }

    public override void Update(float deltaTime)
    {
        Renderer.Clear();

        // TODO: Refactor - and add cameraTransform...
        var primaryCameraEntity = Entities.SingleOrDefault(entity => entity.GetComponent<Camera>()?.IsPrimary ?? false);
        if (primaryCameraEntity != default)
        {
            var cameraTransform = primaryCameraEntity.GetComponent<Transform>();

            var primaryCamera = primaryCameraEntity.GetComponent<Camera>()?.SceneCamera ?? default;
            if (primaryCamera != default)
            {
                Renderer2DSystem.Render(primaryCamera, cameraTransform?.GetTransform() ?? Matrix4.Identity, Entities);
            }
        }
    }
}