using MooseEngine.ECS.Components;
using MooseEngine.ECS.Entities;
using MooseEngine.ECS.Systems;
using MooseEngine.Mathematics.Matrixes;
using System.Collections.ObjectModel;

namespace MooseEngine.SceneManagement;

public interface IScene : IEntityFactory
{
    void OnRuntimeStart();
    void OnRuntimeStop();
    void OnRuntimeUpdate(float deltaTime);
}

internal sealed class Scene : IScene
{
    public Scene(IRenderer2DSystem renderer2DSystem)
    {
        Renderer2DSystem = renderer2DSystem;
    }

    private IRenderer2DSystem Renderer2DSystem { get; }
    private ICollection<IEntity> Entities { get; } = new Collection<IEntity>();

    public IEntity Create(string name = "New Entity")
    {
        var entity = new Entity(Guid.NewGuid(), name);
        entity.AddComponent<Transform>();

        Entities.Add(entity);

        return entity;

    }

    public void OnRuntimeStart()
    {
    }

    public void OnRuntimeStop()
    {
    }

    public void OnRuntimeUpdate(float deltaTime)
    {
        // TODO: Refactor
        var primaryCameraEntity = Entities.SingleOrDefault(entity => entity.GetComponent<Camera>()?.IsPrimary ?? false);
        if (primaryCameraEntity != default)
        {
            var cameraTransform = primaryCameraEntity.GetComponent<Transform>();

            var primaryCamera = primaryCameraEntity.GetComponent<Camera>()?.SceneCamera ?? default;
            if (primaryCamera != default)
            {
                Renderer2DSystem.Render(primaryCamera, cameraTransform?.GetTransform() ?? Matrix4.Identity, Entities);
            }
        }
    }
}
