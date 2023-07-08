using MooseEngine.Events;
using MooseEngine.Graphics;

namespace MooseEngine;

public abstract class LayerBase
{
    public LayerBase(string debugName)
    {
        DebugName = debugName;
    }

    private string DebugName { get; }

    public abstract void OnAttach();
    public abstract void OnDetach();
    public abstract void Update(float deltaTime);
    public virtual void OnEvent(EventBase e)
    {
    }
}

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
    public ApplicationBase(IWindow window)
    {
        Window = window;

        LayerStack = new List<LayerBase>();
    }

    protected IWindow Window { get; }
    private bool IsRunning { get; set; } = true;
    private ICollection<LayerBase> LayerStack { get; set; }

    protected void AttachLayer(LayerBase layer)
    {
        LayerStack.Add(layer);
        layer.OnAttach();
    }

    public void Initialize()
    {
        Window.Initialize();
        Window.SetEventCallback(OnEvent);

        InitializeApplication();
    }

    protected virtual void InitializeApplication()
    {
    }

    public virtual void Run()
    {
        while (IsRunning)
        {
            foreach (var layer in LayerStack)
            {
                layer.Update(0.0f);
            }

            Window.Update();
        }
    }

    private void OnEvent(EventBase e)
    {
        var dispatcher = new EventDispatcher(e);
        dispatcher.Dispatch<WindowCloseEvent>(OnWindowCloseFunc);

        foreach (var layer in LayerStack)
        {
            layer.OnEvent(e);
        }
    }

    private bool OnWindowCloseFunc(WindowCloseEvent arg)
    {
        IsRunning = false;
        return true;
    }

    public void Dispose()
    {
        for (int i = LayerStack.Count - 1; i >= 0; i--)
        {
            var layer = LayerStack.ElementAt(i);
            layer.OnDetach();

            LayerStack.Remove(layer);
        }

        Window.Dispose();
    }
}
