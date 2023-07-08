using GameV1.Interfaces.Items;
using MooseEngine.Graphics;
using MooseEngine.Interfaces;
using System.Numerics;

namespace GameV1.Entities.Factories
{
    public static class ItemFactory
    {
        public static TItem? CreateItem<TItem>(IEntityLayer entityLayer, string name, Vector2 position) where TItem : class, IItem, new()
        {
            TItem? newItem = entityLayer.ActivateOrCreateEntity<TItem>(position);

            newItem.Scale = Vector2.One;
            newItem.ColorTint = Color.White;
            newItem.Name = name;

            if (newItem is IConsumable)
            {
                return newItem;
            }
            else if (newItem is ILightSource)
            {

                return newItem;
            }

            return null;
        }
    }
}
