﻿using GameV1.Interfaces.Containers;
using GameV1.Interfaces.Creatures;
using GameV1.Interfaces.Items;
using MooseEngine.BehaviorTree;
using MooseEngine.Core;
using MooseEngine.Interfaces;

namespace GameV1.Commands
{
    public class ItemDrop : CommandBase
    {
        public IScene Scene { get; set; }
        public ICreature Creature { get; set; }
        public IItem Item { get; set; }

        public ItemDrop(IScene scene, ICreature creature, IItem item)
        {
            Scene = scene;
            Creature = creature;
            Item = item;
        }

        public override NodeStates Execute()
        {
            var itemLayer = Scene.GetLayer((int)EntityLayer.Items);

            IItem? itemAtPosition = (IItem?)Scene.GetEntityAtPosition(itemLayer.ActiveEntities, Creature.Position);

            // Does item exist?
            if (itemAtPosition == null)
            {
                // remove item from Creature inventory
                Creature.Inventory.Inventory.RemoveItem(Item);

                // Attempt to add item to ItemLayer
                itemLayer.ActiveEntities.Add(Item.Position, Item);
                // Console.WriteLine($"{Creature.Name} dropped {Item.Name}");
                return NodeStates.Success;


            }

            // Attempt to add item to Container
            if (itemAtPosition.GetType() == typeof(IContainer))
            {
                var container = (IContainer)itemAtPosition;

                if (container.HasEmptySlots == true)
                {
                    container.AddItemToFirstEmptySlot(Item);
                    // Console.WriteLine($"{Creature.Name} dropped {Item.Name} into {container.Name}");
                    return NodeStates.Success;
                }

            }

            return NodeStates.Success;
        }
    }
}
