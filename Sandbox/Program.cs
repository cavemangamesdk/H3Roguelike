﻿using MooseEngine;
using MooseEngine.Graphics;
using MooseEngine.Mathematics.Vectors;

Engine.Start<SandboxApplication>();

class SandboxApplication : ApplicationBase
{
    public SandboxApplication(IWindow window, IRenderer renderer, IGraphicsFactory graphicsFactory, IRenderer2D renderer2D)
        : base(window)
    {
        Renderer = renderer;
        GraphicsFactory = graphicsFactory;
        Renderer2D = renderer2D;
    }

    private IRenderer Renderer { get; }
    private IGraphicsFactory GraphicsFactory { get; }
    private IRenderer2D Renderer2D { get; }

    protected override void InitializeApplication()
    {
        //AttachLayer(new GettingStarted_HelloTriangleLayer(Renderer, GraphicsFactory));
        //AttachLayer(new GettingStarted_TexturesLayer(Renderer, GraphicsFactory));
        //AttachLayer(new CameraTestLayer(Window, Renderer, GraphicsFactory));
        AttachLayer(new Renderer2DTestLayer(Renderer, Renderer2D));
    }
}

class Renderer2DTestLayer : LayerBase
{
    public Renderer2DTestLayer(IRenderer renderer, IRenderer2D renderer2D) 
        : base("Renderer2D Test Layer")
    {
        Renderer = renderer;
        Renderer2D = renderer2D;
    }

    private IRenderer Renderer { get; }
    private IRenderer2D Renderer2D { get; }

    // Runtime
    private OrthographicCamera? Camera { get; set; }

    public override void OnAttach()
    {
        Renderer2D.Initialize();

        Camera = new OrthographicCamera(2.0f);
        Camera.SetViewport(1024, 768);
    }

    public override void OnDetach()
    {
    }

    public override void Update(float deltaTime)
    {
        Renderer.Clear();
        Renderer2D.BeginScene(Camera);

        Renderer2D.DrawQuad(Vector2.Zero, Vector2.One, Vector4.One);

        Renderer2D.EndScene();
    }
}