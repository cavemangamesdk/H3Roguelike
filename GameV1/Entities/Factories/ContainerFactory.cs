using GameV1.Entities.Containers;
using GameV1.Interfaces.Containers;
using MooseEngine.Interfaces;
using System.Numerics;

namespace GameV1.Entities.Factories
{
    public static class ContainerFactory
    {

        public static IContainer? CreateContainer(ContainerType type, IEntityLayer entityLayer, Vector2 position)
        {
            IContainer? newContainer = entityLayer.ActivateOrCreateEntity<Container>(position);

            if (type == ContainerType.Stationary)
            {

                return newContainer;
            }
            else if (type == ContainerType.Movable)
            {

                return newContainer;
            }
            else if (type == ContainerType.Corpse)
            {

                return newContainer;
            }
            else if (type == ContainerType.PileOfItems)
            {

                return newContainer;
            }

            return null;
        }
    }
}
