using MooseEngine.Graphics;
using MooseEngine.Mathematics.Vectors;

namespace MooseEngine.ECS.Components;

public sealed class SpriteRenderer : ComponentBase
{
    public SpriteRenderer()
        : this(Vector4.One)
    {
    }

    public SpriteRenderer(Vector4 color)
        : this(default, color)
    {
    }

    public SpriteRenderer(ITexture2D sprite)
        : this(sprite, Vector4.One)
    {
        Sprite = sprite;
    }

    public SpriteRenderer(ITexture2D? sprite, Vector4 color)
    {
        Sprite = sprite;
        Color = color;
    }

    public Vector4 Color { get; set; }
    public ITexture2D? Sprite { get; set; }
}