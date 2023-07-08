namespace MooseEngine.Graphics.OpenGL;

internal sealed class OpenGLVertexBuffer : IVertexBuffer
{
    public OpenGLVertexBuffer()
    {
        var vertices = new float[3 * 3] {
            -0.5f, -0.5f, 0.0f,
             0.5f, -0.5f, 0.0f,
             0.0f,  0.5f, 0.0f
        };

        var ids = new uint[1];
        GL.GenBuffers(1, ids);
        RendererId = ids[0];

        Bind();

        GL.BufferData(GLConstants.GL_ARRAY_BUFFER, sizeof(float) * 9, vertices, GLConstants.GL_STATIC_DRAW);
    }

    private uint RendererId { get; }

    public void Bind()
    {
        GL.BindBuffer(GLConstants.GL_ARRAY_BUFFER, RendererId);

        GL.VertexAttribPointer(0, 3, GLConstants.GL_FLOAT, false, 3 * sizeof(float), IntPtr.Zero);
        GL.EnableVertexAttribArray(0);
    }
}
