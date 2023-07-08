using MooseEngine.Extensions.SixLabors.ImageSharp;
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

    public IVertexBuffer CreateVertexBuffer(float[] vertices) => CreateVertexBuffer(vertices, vertices.Length * sizeof(float));
    public IVertexBuffer CreateVertexBuffer(float[] vertices, int size) => new OpenGLVertexBuffer(vertices, size);

    public IIndexBuffer CreateIndexBuffer(uint[] indices) => CreateIndexBuffer(indices, indices.Length);
    public IIndexBuffer CreateIndexBuffer(uint[] indices, int count) => new OpenGLIndexBuffer(indices, 6);

    public IShader CreateShader() => CreateShader("Assets/Shaders/LearnOpenGL/Chapter1/GettingStarted_HelloTriangle.shaderfile");
    public IShader CreateShader(string filepath) => new OpenGLShader(filepath);

    public ITexture2D CreateTexture2D(string filepath) => new OpenGLTexture2D(ImageLoader, filepath);
}

internal sealed class OpenGLTexture2D : ITexture2D
{
    public OpenGLTexture2D(IImageLoader imageLoader, string filepath, bool flipVertically = true)
    {
        var textures = new uint[1];
        GL.GenTextures(1, textures);
        RendererId = textures[0];

        GL.BindTexture(GLConstants.GL_TEXTURE_2D, RendererId);

        GL.TexParameteri(GLConstants.GL_TEXTURE_2D, GLConstants.GL_TEXTURE_WRAP_S, GLConstants.GL_REPEAT);
        GL.TexParameteri(GLConstants.GL_TEXTURE_2D, GLConstants.GL_TEXTURE_WRAP_T, GLConstants.GL_REPEAT);
        GL.TexParameteri(GLConstants.GL_TEXTURE_2D, GLConstants.GL_TEXTURE_MIN_FILTER, GLConstants.GL_NEAREST);
        GL.TexParameteri(GLConstants.GL_TEXTURE_2D, GLConstants.GL_TEXTURE_MAG_FILTER, GLConstants.GL_NEAREST);

        var imageData = imageLoader.LoadImage(filepath, flipVertically);
        IntPtr pointer = IntPtr.Zero;
        if (imageData.Pixels != null)
        {
            pointer = Marshal.AllocHGlobal(imageData.Pixels.Length);
            Marshal.Copy(imageData.Pixels, 0, pointer, imageData.Pixels.Length);
        }
        GL.TexImage2D(GLConstants.GL_TEXTURE_2D, 0, GLConstants.GL_RGBA, imageData.Width, imageData.Height, 0, GLConstants.GL_RGBA, GLConstants.GL_UNSIGNED_BYTE, pointer);

        GL.GenerateMipmap(GLConstants.GL_TEXTURE_2D);
    }

    private uint RendererId { get; }

    public void Bind(uint slot = 0)
    {
        GL.ActiveTexture(GLConstants.GL_TEXTURE0 + slot);
        GL.BindTexture(GLConstants.GL_TEXTURE_2D, RendererId);
    }
}