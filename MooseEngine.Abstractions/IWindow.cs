namespace MooseEngine;

public interface IWindow : IDisposable
{
    bool ShouldClose { get; }

    void Initialize();
    void Update();
}