using MooseEngine.ECS.Components;
using System.Collections.ObjectModel;

namespace MooseEngine.ECS.Entities;

public interface IEntity
{
    Guid Guid { get; }
    string Name { get; }

    TComponent? GetComponent<TComponent>() where TComponent : class, IComponent;
    TComponent AddComponent<TComponent>() where TComponent : class, IComponent, new();
}

internal sealed class Entity : IEntity
{
    public Entity(Guid guid, string name)
    {
        Guid = guid;
        Name = name;
    }

    public Guid Guid { get; set; }
    public string Name { get; set; }

    private ICollection<IComponent> Components { get; } = new Collection<IComponent>();

    public TComponent? GetComponent<TComponent>()
         where TComponent : class, IComponent
    {
        return Components.OfType<TComponent>().FirstOrDefault(component => component?.GetType().Equals(typeof(TComponent)) ?? default);
    }

    public TComponent AddComponent<TComponent>()
        where TComponent : class, IComponent, new()
    {
        var newComponent = new TComponent()
        {
            Entity = this
        };

        Components.Add(newComponent);

        return newComponent;
    }
}

