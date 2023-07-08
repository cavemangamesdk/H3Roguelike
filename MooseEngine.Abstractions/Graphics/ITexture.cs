namespace MooseEngine.Graphics;

public interface ITexture
{
    void Bind(uint slot = 0);
}

public interface ITexture2D : ITexture
{
}