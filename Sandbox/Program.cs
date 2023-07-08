using MooseEngine;
using MooseEngine.Graphics;

Engine.Start<SandboxApplication>();

class SandboxApplication : ApplicationBase
{
    public SandboxApplication(IWindow window, IRenderer renderer, IGraphicsFactory graphicsFactory)
        : base(window, renderer, graphicsFactory)
    {
    }
}