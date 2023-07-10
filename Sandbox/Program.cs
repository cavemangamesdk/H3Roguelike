using MooseEngine;
using MooseEngine.ECS.Components;
using MooseEngine.ECS.Entities;
using MooseEngine.Graphics;
using MooseEngine.Mathematics.Matrixes;
using MooseEngine.Mathematics.Vectors;

Engine.Start<SandboxApplication>();

class SandboxApplication : ApplicationBase
{
    public SandboxApplication(IWindow window, IRenderer renderer, IGraphicsFactory graphicsFactory, IRenderer2D renderer2D, IEntityFactory entityFactory)
        : base(window)
    {
        Renderer = renderer;
        GraphicsFactory = graphicsFactory;
        Renderer2D = renderer2D;
        EntityFactory = entityFactory;
    }

    private IRenderer Renderer { get; }
    private IGraphicsFactory GraphicsFactory { get; }
    private IRenderer2D Renderer2D { get; }
    private IEntityFactory EntityFactory { get; }

    protected override void InitializeApplication()
    {
        //AttachLayer(new GettingStarted_HelloTriangleLayer(Renderer, GraphicsFactory));
        //AttachLayer(new GettingStarted_TexturesLayer(Renderer, GraphicsFactory));
        //AttachLayer(new CameraTestLayer(Window, Renderer, GraphicsFactory));
        //AttachLayer(new Renderer2DTestLayer(Renderer, Renderer2D, GraphicsFactory));
        AttachLayer(new SceneTestLayer(Renderer, Renderer2D, EntityFactory));
    }
}

class SceneTestLayer : LayerBase
{
    public SceneTestLayer(IRenderer renderer, IRenderer2D renderer2D, IEntityFactory entityFactory) 
        : base("Scene Test Layer")
    {
        Renderer = renderer;
        Renderer2D = renderer2D;
        EntityFactory = entityFactory;
    }

    private IRenderer Renderer { get; }
    private IRenderer2D Renderer2D { get; }
    private IEntityFactory EntityFactory { get; }

    // Runtime
    private OrthographicCamera? Camera { get; set; }
    private IEntity Entity { get; set; }

    public override void OnAttach()
    {
        Renderer2D.Initialize();

        Camera = new OrthographicCamera(10.0f);
        Camera.SetViewport(1024, 768);

        Entity = EntityFactory.Create();
        Entity.AddComponent<Transform>();
        var sr = Entity.AddComponent<SpriteRenderer>();
        sr.Color = new Vector4(0.2f, 0.8f, 0.4f, 1.0f);
    }

    public override void OnDetach()
    {
    }

    public override void Update(float deltaTime)
    {
        Renderer.Clear();
        Renderer2D.BeginScene(Camera);

        var entityTransform = Entity.GetComponent<Transform>()?.GetTransform() ?? Matrix4.Identity;
        Renderer2D.DrawQuad(entityTransform, Entity.GetComponent<SpriteRenderer>()?.Color ?? Vector4.ZAxis);

        Renderer2D.EndScene();
    }
}