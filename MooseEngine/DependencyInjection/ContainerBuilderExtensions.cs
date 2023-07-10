using Autofac;
using MooseEngine.ECS.Entity;

namespace MooseEngine.Extensions.DependencyInjection;

public static class ContainerBuilderExtensions
{
    public static ContainerBuilder RegisterCoreModule<TApplication>(this ContainerBuilder containerBuilder)
        where TApplication : ApplicationBase
    {
        containerBuilder.RegisterType<TApplication>()
            .AsImplementedInterfaces()
            .SingleInstance();

        containerBuilder.RegisterType<EntityFactory>()
            .As<IEntityFactory>()
            .InstancePerLifetimeScope();

        return containerBuilder;
    }
}
