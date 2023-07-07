using Autofac;
using MooseEngine.Platform.Glfw;

namespace MooseEngine.Extensions.DependencyInjection;

public class GlfwPlatformModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {

        builder.RegisterType<GlfwWindow>()
            .As<IWindow>()
            .SingleInstance();
    }
}
