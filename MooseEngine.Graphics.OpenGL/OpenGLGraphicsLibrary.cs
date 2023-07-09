using MooseEngine.Extensions.SixLabors.ImageSharp;
using MooseEngine.Graphics.Enumerations;
using System.Runtime.InteropServices;

namespace MooseEngine.Graphics.OpenGL;

internal sealed class OpenGLGraphicsLibrary : IGraphicsFactory
{
    public OpenGLGraphicsLibrary(IImageLoader imageLoader)
    {
        ImageLoader = imageLoader;
    }

    private IImageLoader ImageLoader { get; }

    public IPipeline CreatePipeline(IShader shader, BufferLayout bufferLayout) => new OpenGLPipeline(shader, bufferLayout);

    public IVertexBuffer CreateVertexBuffer(int size, BufferUsage bufferUsage) => new OpenGLVertexBuffer(size, OpenGLHelper.ToGLBufferUsage(bufferUsage));
    public IVertexBuffer CreateVertexBuffer(float[] vertices, BufferUsage bufferUsage) => CreateVertexBuffer(vertices, vertices.Length * sizeof(float), bufferUsage);
    public IVertexBuffer CreateVertexBuffer(float[] vertices, int size, BufferUsage bufferUsage) => new OpenGLVertexBuffer(vertices, size, OpenGLHelper.ToGLBufferUsage(bufferUsage));

    public IIndexBuffer CreateIndexBuffer(uint[] indices, BufferUsage bufferUsage) => CreateIndexBuffer(indices, indices.Length, bufferUsage);
    public IIndexBuffer CreateIndexBuffer(uint[] indices, int count, BufferUsage bufferUsage) => new OpenGLIndexBuffer(indices, count, OpenGLHelper.ToGLBufferUsage(bufferUsage));

    public IShader CreateShader() => CreateShader("Assets/Shaders/LearnOpenGL/Chapter1/GettingStarted_HelloTriangle.shaderfile");
    public IShader CreateShader(string filepath) => new OpenGLShader(filepath);

    public IUniformBuffer CreateUniformBuffer(int size, uint binding, BufferUsage bufferUsage) => new OpenGLUniformBuffer(size, binding, OpenGLHelper.ToGLBufferUsage(bufferUsage));

    public ITexture2D CreateTexture2D(string filepath) => new OpenGLTexture2D(ImageLoader, filepath);
    public ITexture2D CreateTexture2D(int width, int height) => new OpenGLTexture2D(width, height);
}

public static class ObjectExtensions
{
    public static int UnsafeSizeOf<T>(this T obj)
    {
        return System.Runtime.CompilerServices.Unsafe.SizeOf<T>();
    }

    public unsafe static void* GetRawMemoryAddress(this object obj)
    {
        return obj.GetMemoryAddress().ToPointer();
    }

    // TODO: Fix memory leak - Free GChandle somehow?!
    public static IntPtr GetMemoryAddress(this object obj)
    {
        var gcHandle = GCHandle.Alloc(obj, GCHandleType.Pinned);
        return gcHandle.AddrOfPinnedObject();
    }

    public static IntPtr GetMemoryAddress(byte[] bytes)
    {
        var ptr = Marshal.AllocHGlobal(bytes.Length);
        Marshal.Copy(bytes, 0, ptr, bytes.Length);
        return ptr;
    }
}