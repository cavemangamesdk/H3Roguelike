using MooseEngine.Events;

namespace MooseEngine;

public delegate void EventCallbackFn(EventBase e);

public interface IWindow : IDisposable
{
    bool ShouldClose { get; }

    void SetEventCallback(EventCallbackFn eventCallbackFn);

    void Initialize();
    void Update();
}