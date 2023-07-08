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
    }
}


internal sealed class OpenGLVertexBuffer<TVertex> : IVertexBuffer<TVertex>
{
    public OpenGLVertexBuffer(TVertex[] vertices, int size)
    {
        var ids = new uint[1];
        GL.GenBuffers(1, ids);
        RendererId = ids[0];

        Bind();

        GL.BufferData1(GLConstants.GL_ARRAY_BUFFER, size, vertices, GLConstants.GL_STATIC_DRAW);
    }

    private uint RendererId { get; }

    public void Bind()
    {
        GL.BindBuffer(GLConstants.GL_ARRAY_BUFFER, RendererId);
    }

    public void SetData(TVertex[] vertices, int size)
    {
        Bind();

        GL.BufferSubData1(GLConstants.GL_ARRAY_BUFFER, 0, size, vertices);
    }
}
