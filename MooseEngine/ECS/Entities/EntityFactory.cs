namespace MooseEngine.ECS.Entity;

public interface IEntityFactory
{
    IEntity Create(string name = "New Entity");
}

internal sealed class EntityFactory : IEntityFactory
{
    public IEntity Create(string name = "New Entity")
    {
        return new Entity(Guid.NewGuid(), name);
    }
}