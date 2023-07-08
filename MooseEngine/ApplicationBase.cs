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

    private IWindow Window { get; }
    private ICollection<LayerBase> LayerStack { get; set; }

    protected void AttachLayer(LayerBase layer)
    {
        LayerStack.Add(layer);
        layer.OnAttach();
    }

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
        while (!Window.ShouldClose)
        {
            foreach (var layer in LayerStack)
            {
                layer.Update(0.0f);
            }

            Window.Update();
        }
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
