namespace MooseEngine.Graphics;

public interface IRenderer
{
    void Clear();

    void DrawGeometry(IVertexBuffer vertexBuffer);
}
