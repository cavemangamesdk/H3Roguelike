namespace MooseEngine.Graphics;

public interface IRenderer
{
    void Clear();

    void DrawGeometry(IPipeline? pipeline, IVertexBuffer? vertexBuffer);
    void DrawGeometry(IPipeline? pipeline, IVertexBuffer? vertexBuffer, IIndexBuffer? indexBuffer, int indexCount = 0);
}
