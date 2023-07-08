namespace MooseEngine.Graphics.OpenGL;

internal sealed class OpenGLPipeline : IPipeline
{
    public OpenGLPipeline(IShader shader, BufferLayout bufferLayout)
    {
        var ids = new uint[1];
        GL.GenVertexArrays(1, ids);
        RendererId = ids[0];

        GL.BindVertexArray(RendererId);
        Shader = shader;
        BufferLayout = bufferLayout;
    }

    private IShader Shader { get; }
    private BufferLayout BufferLayout { get; }
    private uint RendererId { get; }

    public void Bind()
    {
        Shader.Bind();

        GL.BindVertexArray(RendererId);

        BindBufferLayout();
    }

    private void BindBufferLayout()
    {
        uint index = 0;
        var layout = BufferLayout;
        foreach (var element in layout.Elements)
        {
            var componentCount = element.GetComponentCount();
            var glType = ShaderHelper.ShaderDataTypeToOpenGLBaseType(element.Type);

            GL.EnableVertexAttribArray(index);
            GL.VertexAttribPointer(index, componentCount, glType, element.Normalized, layout.Stride, element.Offset);

            index++;
        }
    }
}
