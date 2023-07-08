using MooseEngine.Graphics.Enumerations;

namespace MooseEngine.Graphics;

public interface IBindable
{
    void Bind();
}

public interface IGraphicsFactory
{
    IPipeline CreatePipeline(IShader shader, BufferLayout bufferLayout);

    IVertexBuffer CreateVertexBuffer(int size, BufferUsage bufferUsage = BufferUsage.StaticDraw);
    IVertexBuffer CreateVertexBuffer(float[] vertices, BufferUsage bufferUsage = BufferUsage.StaticDraw);
    IVertexBuffer CreateVertexBuffer(float[] vertices, int size, BufferUsage bufferUsage = BufferUsage.StaticDraw);

    IIndexBuffer CreateIndexBuffer(uint[] indices, BufferUsage bufferUsage = BufferUsage.StaticDraw);
    IIndexBuffer CreateIndexBuffer(uint[] indices, int count, BufferUsage bufferUsage = BufferUsage.StaticDraw);

    IShader CreateShader();
    IShader CreateShader(string filepath);

    IUniformBuffer CreateUniformBuffer(int size, uint binding, BufferUsage bufferUsage = BufferUsage.StaticDraw);

    ITexture2D CreateTexture2D(string filepath);
}
