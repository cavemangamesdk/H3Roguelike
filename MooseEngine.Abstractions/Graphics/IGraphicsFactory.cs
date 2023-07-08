namespace MooseEngine.Graphics;

public interface IBindable
{
    void Bind();
}

public interface IIndexBuffer : IBindable
{
    int Count { get; }
}

public interface IGraphicsFactory
{
    IPipeline CreatePipeline(IShader shader, BufferLayout bufferLayout);
    IVertexBuffer CreateVertexBuffer();
    IIndexBuffer CreateIndexBuffer();

    IShader CreateShader();
}
