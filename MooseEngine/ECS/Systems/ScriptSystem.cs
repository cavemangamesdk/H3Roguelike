using MooseEngine.ECS.Components;
using MooseEngine.ECS.Entities;

namespace MooseEngine.ECS.Systems;

public interface IScriptSystem : IECSSystem
{
    void Start(IEnumerable<IEntity> entities);
    void Stop(IEnumerable<IEntity> entities);
    void Update(IEnumerable<IEntity> entities, float deltaTime);
}

internal sealed class ScriptSystem : IScriptSystem
{
    public void Start(IEnumerable<IEntity> entities)
    {
        var scriptableEntities = entities.Where(entity =>
        {
            return entity.HasComponent<Script>();
        });

        foreach (var entity in scriptableEntities)
        {
            // TODO: Error/Warning log if ScriptReference is null
            entity.GetComponent<Script>()?.ScriptReference?.Start();
        }
    }

    public void Stop(IEnumerable<IEntity> entities)
    {
        var scriptableEntities = entities.Where(entity =>
        {
            return entity.HasComponent<Script>();
        });

        foreach (var entity in scriptableEntities)
        {
            entity.GetComponent<Script>()?.ScriptReference?.Stop();
        }
    }

    public void Update(IEnumerable<IEntity> entities, float deltaTime)
    {
        var scriptableEntities = entities.Where(entity =>
        {
            return entity.HasComponent<Script>();
        });

        foreach(var entity in scriptableEntities)
        {
            entity.GetComponent<Script>()?.ScriptReference?.Update(deltaTime);
        }
    }
}
