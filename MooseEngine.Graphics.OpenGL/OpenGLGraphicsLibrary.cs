namespace MooseEngine.Graphics.OpenGL;

internal sealed class OpenGLGraphicsLibrary : IGraphicsFactory
{
    public IPipeline CreatePipeline()
    {
        return new OpenGLPipeline();
    }

    public IVertexBuffer CreateVertexBuffer()
    {
        return new OpenGLVertexBuffer();
    }

    public IShader CreateShader()
    {
        return new OpenGLShader();
    }
}
