using MooseEngine.ECS.Components;
using MooseEngine.ECS.Entities;
using MooseEngine.Graphics;
using MooseEngine.Mathematics.Matrixes;
using MooseEngine.Mathematics.Vectors;

namespace MooseEngine.ECS.Systems;

public interface IRenderer2DSystem : IECSSystem
{
    void Render(ICamera camera, Matrix4 cameraTransform, IEnumerable<IEntity> entities);
}

internal sealed class Renderer2DSystem : IRenderer2DSystem
{
    public Renderer2DSystem(IRenderer2D renderer2D)
    {
        Renderer2D = renderer2D;
    }

    private IRenderer2D Renderer2D { get; }

    public void Render(ICamera camera, Matrix4 cameraTransform, IEnumerable<IEntity> entities)
    {
        var renderableEntities = entities.Select(entity =>
        {
            if (!entity.HasComponent<Transform>())
            {
                return default;
            }
            if (!entity.HasComponent<SpriteRenderer>())
            {
                return default;
            }

            return entity;
        }).Where(entity => entity != default);

        Renderer2D.BeginScene(camera, cameraTransform);

        foreach (var entity in renderableEntities)
        {
            var transform = entity?.GetComponent<Transform>()?.GetTransform() ?? Matrix4.Identity;
            var spriteRenderer = entity?.GetComponent<SpriteRenderer>() ?? default;

            if (spriteRenderer?.Sprite != default)
            {
                Renderer2D.DrawQuad(transform, spriteRenderer.Sprite, spriteRenderer?.Color ?? Vector4.YAxis);
            }
            else
            {
                Renderer2D.DrawQuad(transform, spriteRenderer?.Color ?? Vector4.YAxis);
            }
        }

        Renderer2D.EndScene();
    }
}
