using MooseEngine.Graphics.OpenGL.Enumerations;

namespace MooseEngine.Graphics.OpenGL;

internal sealed class OpenGLIndexBuffer : IIndexBuffer
{
    public OpenGLIndexBuffer(uint[] indices, int count, GLBufferUsage bufferUsage)
    {
        Count = count;

        var ids = new uint[1];
        GL.GenBuffers(1, ids);
        RendererId = ids[0];
        Bind();

        GL.BufferData(GLBufferBindingTarget.ElementArrayBuffer, count * sizeof(uint), indices.GetMemoryAddress(), bufferUsage);
    }

    public int Count { get; }
    private uint RendererId { get; }

    public void Bind()
    {
        GL.BindBuffer(GLBufferBindingTarget.ElementArrayBuffer, RendererId);
    }
}
