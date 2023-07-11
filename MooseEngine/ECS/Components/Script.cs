using MooseEngine.ECS.Entities;

namespace MooseEngine.ECS.Components;

public sealed class Script : ComponentBase
{
    internal IScriptBehaviourReference? ScriptReference { get; set; }

    public void AttachScriptReference<TScriptReference>()
        where TScriptReference : ScriptBehaviour, new()
    {
        var entity = ((IComponent)this).Entity;
        ScriptReference = new TScriptReference()
        {
            Entity = entity
        };
    }
}

public abstract class ScriptBehaviour : IScriptBehaviourReference
{
    protected internal IEntity? Entity { get; internal set; }

    public virtual void Start()
    {
    }

    public virtual void Stop()
    {
    }

    public virtual void Update(float deltaTime)
    {
    }
}

public interface IScriptBehaviourReference
{
    void Start();
    void Stop();
    void Update(float deltaTime);
}