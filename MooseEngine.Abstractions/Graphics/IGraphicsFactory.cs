namespace MooseEngine.Graphics;

public interface IBindable
{
    void Bind();
    void Unbind();
}

public interface IGraphicsFactory
{
    IPipeline CreatePipeline();
    IVertexBuffer CreateVertexBuffer();

    IShader CreateShader();
}
