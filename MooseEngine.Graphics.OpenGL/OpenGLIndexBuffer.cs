namespace MooseEngine.Graphics.OpenGL;

internal sealed class OpenGLIndexBuffer : IIndexBuffer
{
    public OpenGLIndexBuffer(uint[] indices, int count)
    {
        Count = count;

        var ids = new uint[1];
        GL.GenBuffers(1, ids);
        RendererId = ids[0];
        Bind();

        GL.BufferData(GLConstants.GL_ELEMENT_ARRAY_BUFFER, count * sizeof(uint), indices, GLConstants.GL_STATIC_DRAW);
    }

    public int Count { get; }
    private uint RendererId { get; }

    public void Bind()
    {
        GL.BindBuffer(GLConstants.GL_ELEMENT_ARRAY_BUFFER, RendererId);
    }
}