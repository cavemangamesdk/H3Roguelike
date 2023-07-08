namespace MooseEngine.Graphics.OpenGL;

internal sealed class OpenGLGraphicsLibrary : IGraphicsFactory
{
    public IPipeline CreatePipeline(IShader shader, BufferLayout bufferLayout)
    {
        return new OpenGLPipeline(shader, bufferLayout);
    }

    public IVertexBuffer CreateVertexBuffer()
    {
        var vertices = new float[3 * 3] {
            -0.5f, -0.5f, 0.0f,
             0.5f, -0.5f, 0.0f,
             0.0f,  0.5f, 0.0f
        };

        return new OpenGLVertexBuffer(vertices, 9 * sizeof(float));
    }

    public IShader CreateShader()
    {
        return new OpenGLShader();
    }
}
