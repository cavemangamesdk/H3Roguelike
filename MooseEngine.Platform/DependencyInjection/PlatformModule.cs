using Autofac;

namespace MooseEngine.Extensions.DependencyInjection;

public class PlatformModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterModule<GlfwPlatformModule>();
    }
}
