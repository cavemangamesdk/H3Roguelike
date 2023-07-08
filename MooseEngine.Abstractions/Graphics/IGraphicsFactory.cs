namespace MooseEngine.Graphics;

public interface IBindable
{
    void Bind();
}

public interface IGraphicsFactory
{
    IPipeline CreatePipeline(IShader shader, BufferLayout bufferLayout);
    IVertexBuffer CreateVertexBuffer();

    IShader CreateShader();
}
