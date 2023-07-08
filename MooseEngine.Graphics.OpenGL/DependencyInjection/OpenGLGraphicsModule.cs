using Autofac;
using MooseEngine.Graphics;
using MooseEngine.Graphics.OpenGL;

namespace MooseEngine.Extensions.DependencyInjection;

public class OpenGLGraphicsModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<OpenGLRenderer>()
            .As<IRenderer>()
            .SingleInstance();

        builder.RegisterType<OpenGLGraphicsLibrary>()
            .As<IGraphicsFactory>()
            .SingleInstance();
    }
}
