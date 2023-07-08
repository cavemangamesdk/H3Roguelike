using Autofac;
using MooseEngine.Extensions.SixLabors.ImageSharp;

namespace MooseEngine.Extensions.DependencyInjection;

public static class ContainerBuilderExtensions
{
    public static ContainerBuilder RegisterImageLoader(this ContainerBuilder builder)
    {
        builder.RegisterType<ImageLoader>()
            .As<IImageLoader>()
            .InstancePerLifetimeScope();

        return builder;
    }
}
