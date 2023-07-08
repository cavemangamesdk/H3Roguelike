namespace MooseEngine.Graphics;

public interface IUniformBuffer : IBindable
{
    void SetData<T>(T data, int size, int offset = 0);
}