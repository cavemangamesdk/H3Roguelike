using MooseEngine.Graphics.Enumerations;
using MooseEngine.Graphics.OpenGL.Enumerations;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        var handle = vertices.GetMemoryAddress();

        GL.BufferData(GLBufferBindingTarget.ArrayBuffer, size, handle.AddrOfPinnedObject(), bufferUsage);

        handle.Free();

    }

    private uint RendererId { get; }

    public void Bind()
    {
        GL.BindBuffer(GLBufferBindingTarget.ArrayBuffer, RendererId);
    }

    public void SetData<T>(T[] vertices, int size)
    {
        Bind();

        var handle = vertices.GetMemoryAddress();

        GL.BufferSubData(GLBufferBindingTarget.ArrayBuffer, 0, size, handle.AddrOfPinnedObject());

        handle.Free();
    }

    private uint CreateVertexBuffer()
    {
        var ids = new uint[1];
        GL.GenBuffers(1, ids);
        return ids[0];
    }
}
