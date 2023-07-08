namespace MooseEngine.Graphics.OpenGL.Enumerations;

public enum GLBufferBindingTarget : uint
{
    ArrayBuffer = GLConstants.GL_ARRAY_BUFFER,
    ElementArrayBuffer = GLConstants.GL_ELEMENT_ARRAY_BUFFER,
    UniformBuffer = GLConstants.GL_UNIFORM_BUFFER,

    AtomicCounterBuffer = 0xFFFF,
    CopyReadBuffer = 0xFFFF,
    CopyWriteBuffer = 0xFFFF,
    DispatchIndirectBuffer = 0xFFFF,
    PixelPackBuffer = 0xFFFF,
    PixelUnpackBuffer = 0xFFFF,
    QueryBuffer = 0xFFFF,
    ShaderStorageBuffer = 0xFFFF,
    TextureBuffer = 0xFFFF,
    TransformFeedbackBuffer = 0xFFFF
}
