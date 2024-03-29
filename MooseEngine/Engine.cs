﻿using Autofac;
using MooseEngine.DependencyInjection;
using MooseEngine.Extensions.DependencyInjection;

namespace MooseEngine;

public static class Engine
{
    public static void Start<TApplication>()
        where TApplication : ApplicationBase
    {
        var containerBuilder = new ContainerBuilder();

        containerBuilder.RegisterCoreModule<TApplication>();

        containerBuilder.RegisterModule<PlatformModule>();
        containerBuilder.RegisterModule<GraphicsModule>();

        var container = containerBuilder.Build();

        using var scope = container.BeginLifetimeScope();

        using var application = scope.Resolve<IExecutableApplication>();

        application.Initialize();

        application.Run();
    }
}
