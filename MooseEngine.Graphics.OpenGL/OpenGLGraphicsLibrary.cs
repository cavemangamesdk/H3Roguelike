using MooseEngine.Extensions.SixLabors.ImageSharp;

namespace MooseEngine.Graphics.OpenGL;

internal sealed class OpenGLGraphicsLibrary : IGraphicsFactory
{
    public OpenGLGraphicsLibrary(IImageLoader imageLoader)
    {
        ImageLoader = imageLoader;
    }

    private IImageLoader ImageLoader { get; }

    public IPipeline CreatePipeline(IShader shader, BufferLayout bufferLayout) => new OpenGLPipeline(shader, bufferLayout);

    public IVertexBuffer<TVertex> CreateVertexBuffer<TVertex>(TVertex[] vertices, int size) => new OpenGLVertexBuffer<TVertex>(vertices, size);

    public IVertexBuffer CreateVertexBuffer(float[] vertices) => CreateVertexBuffer(vertices, vertices.Length * sizeof(float));
    public IVertexBuffer CreateVertexBuffer(float[] vertices, int size) => new OpenGLVertexBuffer(vertices, size);

    public IIndexBuffer CreateIndexBuffer(uint[] indices) => CreateIndexBuffer(indices, indices.Length);
    public IIndexBuffer CreateIndexBuffer(uint[] indices, int count) => new OpenGLIndexBuffer(indices, 6);

    public IShader CreateShader() => CreateShader("Assets/Shaders/LearnOpenGL/Chapter1/GettingStarted_HelloTriangle.shaderfile");
    public IShader CreateShader(string filepath) => new OpenGLShader(filepath);

    public IUniformBuffer CreateUniformBuffer(int size, uint binding) => new OpenGLUniformBuffer(size, binding);

    public ITexture2D CreateTexture2D(string filepath) => new OpenGLTexture2D(ImageLoader, filepath);
}

internal sealed class OpenGLUniformBuffer : IUniformBuffer
{
    public OpenGLUniformBuffer(int size, uint binding)
    {
        var UBOs = new uint[1];
        GL.GenBuffers(1, UBOs);

        RendererID = UBOs[0];

        Bind();

        GL.BufferData1(GLConstants.GL_UNIFORM_BUFFER, size, default!, GLConstants.GL_DYNAMIC_DRAW);

        GL.BindBufferBase(GLConstants.GL_UNIFORM_BUFFER, binding, RendererID);
    }

    private uint RendererID { get; set; }

    public void SetData(float[] data, int size, int offset = 0)
    {
        Bind();

        GL.BufferSubData(GLConstants.GL_UNIFORM_BUFFER, offset, size, data);
    }

    public void Bind()
    {
        GL.BindBuffer(GLConstants.GL_UNIFORM_BUFFER, RendererID);
    }
}