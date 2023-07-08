namespace MooseEngine.Graphics;

public interface IVertexBuffer
{
    void Bind();
    void SetData<T>(T[] vertices, int size);
}

public interface IVertexBuffer<TVertex> : IVertexBuffer
{
    void SetData(TVertex[] vertices, int size);
}