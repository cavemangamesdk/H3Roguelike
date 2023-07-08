namespace MooseEngine.Graphics;

public interface IBindable
{
    void Bind();
}

public interface IGraphicsFactory
{
    IPipeline CreatePipeline();
    IVertexBuffer CreateVertexBuffer();

    IShader CreateShader();
}
