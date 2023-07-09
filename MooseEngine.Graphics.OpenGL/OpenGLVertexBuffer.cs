using MooseEngine.Graphics.OpenGL.Enumerations;
using System.Runtime.InteropServices;

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
        GL.BindBuffer(GLBufferBindingTarget.ArrayBuffer, RendererId);
    }

    public void SetData<T>(T[] vertices, int size)
    {
        Bind();

        var verticesPtr = vertices.GetMemoryAddress();

        GL.BufferSubData(GLBufferBindingTarget.ArrayBuffer, 0, size, verticesPtr);

        Marshal.FreeHGlobal(verticesPtr);
    }

    private uint CreateVertexBuffer()
    {
        var ids = new uint[1];
        GL.GenBuffers(1, ids);
        return ids[0];
    }
}
