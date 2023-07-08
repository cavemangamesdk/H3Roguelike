namespace MooseEngine.Graphics.OpenGL;

internal sealed class OpenGLGraphicsLibrary : IGraphicsFactory
{
    public IPipeline CreatePipeline(IShader shader, BufferLayout bufferLayout) => new OpenGLPipeline(shader, bufferLayout);

    public IVertexBuffer CreateVertexBuffer(float[] vertices) => CreateVertexBuffer(vertices, vertices.Length * sizeof(float));
    public IVertexBuffer CreateVertexBuffer(float[] vertices, int size) => new OpenGLVertexBuffer(vertices, size);

    public IIndexBuffer CreateIndexBuffer(uint[] indices) => CreateIndexBuffer(indices, indices.Length);
    public IIndexBuffer CreateIndexBuffer(uint[] indices, int count) => new OpenGLIndexBuffer(indices, 6);

    public IShader CreateShader() => CreateShader("Assets/Shaders/LearnOpenGL/Chapter1/GettingStarted_HelloTriangle.shaderfile");
    public IShader CreateShader(string filepath) => new OpenGLShader(filepath);
}
