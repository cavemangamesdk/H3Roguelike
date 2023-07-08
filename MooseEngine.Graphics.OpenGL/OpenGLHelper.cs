using MooseEngine.Graphics.Enumerations;
using MooseEngine.Graphics.OpenGL.Enumerations;

namespace MooseEngine.Graphics.OpenGL;

internal static class OpenGLHelper
{
    internal static GLBufferUsage ToGLBufferUsage(BufferUsage bufferUsage)
    {
        return bufferUsage switch
        {
            BufferUsage.StaticDraw  => GLBufferUsage.StaticDraw,
            BufferUsage.StaticRead  => GLBufferUsage.StaticRead,
            BufferUsage.StaticCopy  => GLBufferUsage.StaticCopy,
            BufferUsage.DynamicDraw => GLBufferUsage.DynamicDraw,
            BufferUsage.DynamicRead => GLBufferUsage.DynamicRead,
            BufferUsage.DynamicCopy => GLBufferUsage.DynamicCopy,
            BufferUsage.StreamDraw  => GLBufferUsage.StreamDraw,
            BufferUsage.StreamRead  => GLBufferUsage.StreamRead,
            BufferUsage.StreamCopy  => GLBufferUsage.StreamCopy,
            _                       => GLBufferUsage.StaticDraw,
        };
    }
}