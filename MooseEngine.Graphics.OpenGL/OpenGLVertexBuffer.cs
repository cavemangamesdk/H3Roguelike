using MooseEngine.Graphics.OpenGL.Enumerations;

namespace MooseEngine.Graphics.OpenGL;

internal sealed class OpenGLVertexBuffer : IVertexBuffer
{
    public OpenGLVertexBuffer(int size, GLBufferUsage bufferUsage)
    {
        RendererId = CreateVertexBuffer();

        Bind();

        GL.BufferData(GLBufferBindingTarget.ArrayBuffer, size, IntPtr.Zero, bufferUsage);
    }

    public OpenGLVertexBuffer(float[] vertices, int size, GLBufferUsage bufferUsage)
    {
        RendererId = CreateVertexBuffer();

        Bind();

        GL.BufferData(GLBufferBindingTarget.ArrayBuffer, size, vertices.GetMemoryAddress(), bufferUsage);
    }

    private uint RendererId { get; }

    public void Bind()
    {
        GL.BindBuffer(GLConstants.GL_ARRAY_BUFFER, RendererId);
    }

    public void SetData<T>(T[] vertices, int size)
    {
        Bind();

        GL.BufferSubData(GLConstants.GL_ARRAY_BUFFER, 0, size, vertices.GetMemoryAddress());
    }

    private uint CreateVertexBuffer()
    {
        var ids = new uint[1];
        GL.GenBuffers(1, ids);
        return ids[0];
    }
}
