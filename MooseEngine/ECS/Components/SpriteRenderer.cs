using MooseEngine.Mathematics.Vectors;

namespace MooseEngine.ECS.Components;

public sealed class SpriteRenderer : ComponentBase
{
    public SpriteRenderer()
        : this(Vector4.One)
    {
    }

    public SpriteRenderer(Vector4 color)
    {
        Color = color;
    }

    public Vector4 Color { get; set; }
}