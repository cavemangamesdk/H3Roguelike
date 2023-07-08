namespace MooseEngine.Graphics;

public interface IShader
{
    void Bind();

    void SetInt(string name, int value);
}
