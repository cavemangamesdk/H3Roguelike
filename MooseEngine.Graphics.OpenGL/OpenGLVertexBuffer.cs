namespace MooseEngine.Graphics.OpenGL;

internal sealed class OpenGLVertexBuffer : IVertexBuffer
{
    public OpenGLVertexBuffer(float[] vertices, int size)
    {
        var ids = new uint[1];
        GL.GenBuffers(1, ids);
        RendererId = ids[0];

        Bind();

        GL.BufferData(GLConstants.GL_ARRAY_BUFFER, size, vertices, GLConstants.GL_STATIC_DRAW);
    }

    private uint RendererId { get; }

    public void Bind()
    {
        GL.BindBuffer(GLConstants.GL_ARRAY_BUFFER, RendererId);

        GL.VertexAttribPointer(0, 3, GLConstants.GL_FLOAT, false, 3 * sizeof(float), IntPtr.Zero);
        GL.EnableVertexAttribArray(0);
    }
}

