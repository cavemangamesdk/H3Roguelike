namespace MooseEngine.Graphics.OpenGL;

internal sealed class OpenGLPipeline : IPipeline
{
    public OpenGLPipeline()
    {
        var ids = new uint[1];
        GL.GenVertexArrays(1, ids);
        RendererId = ids[0];

        GL.BindVertexArray(RendererId);
    }

    private uint RendererId { get; }

    public void Bind()
    {
        GL.BindVertexArray(RendererId);
    }
}
