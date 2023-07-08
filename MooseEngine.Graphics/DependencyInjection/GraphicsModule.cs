using Autofac;
using MooseEngine.Graphics;

namespace MooseEngine.Extensions.DependencyInjection;

public class GraphicsModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterModule<OpenGLGraphicsModule>();

        builder.RegisterType<Renderer2D>()
            .As<IRenderer2D>()
            .SingleInstance();
    }
}
