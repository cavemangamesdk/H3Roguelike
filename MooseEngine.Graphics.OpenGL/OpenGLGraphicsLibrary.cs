using System.Drawing;

namespace MooseEngine.Graphics.OpenGL;

internal sealed class OpenGLGraphicsLibrary : IGraphicsFactory
{
    public IPipeline CreatePipeline(IShader shader, BufferLayout bufferLayout)
    {
        return new OpenGLPipeline(shader, bufferLayout);
    }

    public IVertexBuffer CreateVertexBuffer()
    {
        var vertices = new float[4 * 3] {
             0.5f,  0.5f, 0.0f,  // top right
             0.5f, -0.5f, 0.0f,  // bottom right
            -0.5f, -0.5f, 0.0f,  // bottom left
            -0.5f,  0.5f, 0.0f   // top left 
        };

        //var vertices = new float[3 * 3] {
        //    -0.5f, -0.5f, 0.0f,
        //     0.5f, -0.5f, 0.0f,
        //     0.0f,  0.5f, 0.0f
        //};

        return new OpenGLVertexBuffer(vertices, 12 * sizeof(float));
    }

    public IIndexBuffer CreateIndexBuffer()
    {
        var indices = new uint[] {  // note that we start from 0!
            0, 1, 3,   // first triangle
            1, 2, 3    // second triangle
        };

        return new OpenGLIndexBuffer(indices, 6);
    }

    public IShader CreateShader()
    {
        return new OpenGLShader();
    }
}
