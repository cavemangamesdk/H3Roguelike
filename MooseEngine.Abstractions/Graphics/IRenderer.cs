namespace MooseEngine.Graphics;

public interface IRenderer
{
    void Initialize();
    void Clear();

    void SetViewport(int width, int height);
    void SetViewport(int x, int y, int width, int height);

    void DrawGeometry(IPipeline? pipeline, IVertexBuffer? vertexBuffer);
    void DrawGeometry(IPipeline? pipeline, IVertexBuffer? vertexBuffer, IIndexBuffer? indexBuffer, int indexCount = 0);
}
