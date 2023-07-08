using MooseEngine.Interfaces;
using System.Numerics;

namespace GameV1.Entities.Factories
{
    public static class EntityFactory
    {
        public static TEntity? CreateEntity<TEntity>(IEntityLayer entityLayer, string name, Vector2 position) where TEntity : class, IEntity, new()
        {
            TEntity? newEntity = entityLayer.ActivateOrCreateEntity<TEntity>(position);

            newEntity.Name = name;


            return newEntity;
        }
    }
}
