using Autofac;
using MooseEngine.ECS.Entities;
using MooseEngine.ECS.Systems;

namespace MooseEngine.DependencyInjection;

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

        containerBuilder.RegisterAssemblyTypes(typeof(MooseEngineOptions).Assembly)
            .AssignableTo<IECSSystem>()
            .AsImplementedInterfaces();

        return containerBuilder;
    }
}
