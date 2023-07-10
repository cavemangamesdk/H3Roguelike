using MooseEngine.Graphics.OpenGL.Enumerations;

namespace MooseEngine.Graphics.OpenGL;

internal sealed class OpenGLUniformBuffer : IUniformBuffer
{
    public OpenGLUniformBuffer(int size, uint binding, GLBufferUsage bufferUsage)
    {
        var UBOs = new uint[1];
        GL.GenBuffers(1, UBOs);

        RendererID = UBOs[0];

        Bind();

        GL.BufferData(GLBufferBindingTarget.UniformBuffer, size, IntPtr.Zero, bufferUsage);

        GL.BindBufferBase(GLBufferBindingTarget.UniformBuffer, binding, RendererID);
    }

    private uint RendererID { get; set; }

    public void SetData<T>(T data, int size, int offset = 0)
    {
        if(data == null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        Bind();

        var handle = data.GetMemoryAddress();

        GL.BufferSubData(GLBufferBindingTarget.UniformBuffer, offset, size, handle.AddrOfPinnedObject());

        handle.Free();
    }

    public void Bind()
    {
        GL.BindBuffer(GLBufferBindingTarget.UniformBuffer, RendererID);
    }
}
