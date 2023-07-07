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
    public ApplicationBase(IWindow window, IRenderer renderer)
    {
        Window = window;
        Renderer = renderer;
    }

    private IWindow Window { get; }
    private IRenderer Renderer { get; }

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
        while(!Window.ShouldClose)
        {
            Window.Update();

            Renderer.Clear();
        }
    }

    public void Dispose()
    {
        Window.Dispose();
    }
}
