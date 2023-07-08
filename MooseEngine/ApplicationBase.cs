using MooseEngine.Graphics;

namespace MooseEngine;

public interface IApplication
{
}

internal interface IExecutableApplication : IDisposable
{
    void Initialize();
    void Run();
}

public abstract class ApplicationBase : IApplication, IExecutableApplication
{
    public ApplicationBase(IWindow window, IRenderer renderer, IGraphicsFactory graphicsFactory)
    {
        Window = window;
        Renderer = renderer;
        GraphicsFactory = graphicsFactory;
    }

    private IWindow Window { get; }
    private IRenderer Renderer { get; }
    private IGraphicsFactory GraphicsFactory { get; }

    public void Initialize()
    {
        Window.Initialize();

        InitializeApplication();
    }

    protected virtual void InitializeApplication()
    {
    }

    public virtual void Run()
    {
        var shader = GraphicsFactory.CreateShader();

        var bufferLayout = new BufferLayout(new List<BufferElement>
        {
            new BufferElement("aPos", ShaderDataType.Float3)
        });
        var pipeline = GraphicsFactory.CreatePipeline(shader, bufferLayout);
        var vbo = GraphicsFactory.CreateVertexBuffer();

        while(!Window.ShouldClose)
        {
            Window.Update();

            Renderer.Clear();

            Renderer.DrawGeometry(pipeline, vbo);
        }
    }

    public void Dispose()
    {
        Window.Dispose();
    }
}
