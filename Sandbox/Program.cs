using MooseEngine;
using MooseEngine.Graphics;

Engine.Start<SandboxApplication>();

class SandboxApplication : ApplicationBase
{
    public SandboxApplication(IWindow window, IRenderer renderer)
        : base(window, renderer)
    {
    }
}