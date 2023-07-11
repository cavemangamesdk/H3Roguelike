using DotnetNoise;
using MooseEngine;
using MooseEngine.ECS.Components;
using MooseEngine.Events;
using MooseEngine.Graphics;
using MooseEngine.Mathematics.Vectors;
using MooseEngine.SceneManagement;
using System.Runtime.CompilerServices;

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

        Renderer.Initialize();
        Renderer2D.Initialize();

        //AttachLayer(new GettingStarted_HelloTriangleLayer(Renderer, GraphicsFactory));
        //AttachLayer(new GettingStarted_TexturesLayer(Renderer, GraphicsFactory));
        //AttachLayer(new CameraTestLayer(Window, Renderer, GraphicsFactory));
        //AttachLayer(new Renderer2DTestLayer(Renderer, Renderer2D, GraphicsFactory));
        //AttachLayer(new SceneTestLayer(Renderer, Renderer2D, GraphicsFactory, SceneFactory));
        AttachLayer(new RoguelikeTestLayer(Renderer, Renderer2D, GraphicsFactory, SceneFactory));
    }
}

class RoguelikeTestLayer : LayerBase
{
    public RoguelikeTestLayer(IRenderer renderer, IRenderer2D renderer2D, IGraphicsFactory graphicsFactory, ISceneFactory sceneFactory)
        : base("Roguelike Test Layer")
    {
        Renderer = renderer;
        Renderer2D = renderer2D;
        GraphicsFactory = graphicsFactory;
        SceneFactory = sceneFactory;
    }

    private IRenderer Renderer { get; }
    private IRenderer2D Renderer2D { get; }
    private IGraphicsFactory GraphicsFactory { get; }
    private ISceneFactory SceneFactory { get; }

    // Runtime
    private IScene? Scene { get; set; }

    public override void OnAttach()
    {
        Scene = SceneFactory.CreateScene();

        var cameraEntity = Scene.Create("Camera");
        var cameraScript = cameraEntity.AddComponent<Script>();
        cameraScript.AttachScriptReference<CameraControllerScriptBehaviour>();

        var camera = cameraEntity.AddComponent<Camera>();
        camera.SceneCamera.SetViewport(1024, 768);
        camera.SceneCamera.SetOrthographic(5.0f, -1.0f, 1.0f);

        var noiseMap = ProceduralAlgorithms.GeneratePerlinNoiseMap(100, 100, 1.0f, Random.Shared.Next());

        var containerTexture = GraphicsFactory.CreateTexture2D("Assets/Textures/container.jpg");
        var awesomefaceTexture = GraphicsFactory.CreateTexture2D("Assets/Textures/awesomeface.png");
        foreach (var tile in noiseMap)
        {
            var entity = Scene.Create($"Map ({tile.Key.X}, {tile.Key.Y}) - {tile.Value}");
            var transform = entity.GetComponent<Transform>();
            transform.Position = new Vector3(tile.Key.X, tile.Key.Y, 0.0f);

            var spriteRenderer = entity.AddComponent<SpriteRenderer>();

            if (tile.Value > -0.3f && tile.Value < 0.3f)
            {
                spriteRenderer.Sprite = containerTexture;
                continue;
            }

            spriteRenderer.Sprite = awesomefaceTexture;
        }

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

static class ProceduralAlgorithms
{
    public static Dictionary<Vector2, float> GeneratePerlinNoiseMap(int width, int height, float worldScale, int seed)
    {
        Dictionary<Vector2, float> noiseMap = new Dictionary<Vector2, float>();
        FastNoise noise = new FastNoise(seed);
        noise.UsedNoiseType = FastNoise.NoiseType.Perlin;

        for (int y = 0; y < height; y++)
        {
            var yCord = y * (int)worldScale;
            for (int x = 0; x < width; x++)
            {
                var xCord = x * (int)worldScale;
                noiseMap.Add(new Vector2(xCord, yCord), noise.GetPerlin(xCord, yCord));
            }
        }

        return noiseMap;
    }
}