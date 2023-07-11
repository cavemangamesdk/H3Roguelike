using MooseEngine.Events;

namespace MooseEngine;

public delegate void EventCallbackFn(EventBase e);

public interface IWindow : IDisposable
{
    int Width { get; }
    int Height { get; }

    bool ShouldClose { get; }

    void SetEventCallback(EventCallbackFn eventCallbackFn);

    void Initialize();
    void Update();

    float GetTime();
}