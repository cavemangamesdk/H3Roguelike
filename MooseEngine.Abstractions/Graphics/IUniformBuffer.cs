namespace MooseEngine.Graphics;

public interface IUniformBuffer : IBindable
{
    void SetData(float[] data, int size, int offset = 0);
}