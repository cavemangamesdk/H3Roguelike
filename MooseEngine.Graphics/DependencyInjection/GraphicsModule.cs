using Autofac;

namespace MooseEngine.Extensions.DependencyInjection;

public class GraphicsModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterModule<OpenGLGraphicsModule>();
    }
}
