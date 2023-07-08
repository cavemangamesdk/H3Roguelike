namespace MooseEngine.Graphics;

public interface IVertexBuffer
{
    void Bind();
}

public interface IVertexBuffer<TVertex> : IVertexBuffer
{
    void SetData(TVertex[] vertices, int size);
}