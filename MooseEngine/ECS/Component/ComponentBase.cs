using MooseEngine.ECS.Entity;

namespace MooseEngine.ECS.Component;

public interface IComponent
{
    protected internal IEntity? Entity { get; internal set; }
}

public abstract class ComponentBase : IComponent
{
    IEntity? IComponent.Entity { get; set; }
}
