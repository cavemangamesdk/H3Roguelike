using MooseEngine.Graphics.OpenGL.Enumerations;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        var handle = indices.GetMemoryAddress();

        GL.BufferData(GLBufferBindingTarget.ElementArrayBuffer, count * sizeof(uint), handle.AddrOfPinnedObject(), bufferUsage);

        handle.Free();
    }

    public int Count { get; }
    private uint RendererId { get; }

    public void Bind()
    {
        GL.BindBuffer(GLBufferBindingTarget.ElementArrayBuffer, RendererId);
    }
}
