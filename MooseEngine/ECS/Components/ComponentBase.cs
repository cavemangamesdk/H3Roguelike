using MooseEngine.ECS.Entities;

namespace MooseEngine.ECS.Components;

public interface IComponent
{
    protected internal IEntity? Entity { get; internal set; }
}

public abstract class ComponentBase : IComponent
{
    IEntity? IComponent.Entity { get; set; }
}
