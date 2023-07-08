namespace MooseEngine.Graphics;

public interface IRenderer
{
    void Clear();

    void DrawGeometry(IPipeline? pipeline, IVertexBuffer? vertexBuffer);
}
