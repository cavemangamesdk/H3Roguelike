﻿using GameV1.Entities.Containers;
using GameV1.Entities.Creatures;
using GameV1.Interfaces.Containers;
using GameV1.Interfaces.Creatures;
using GameV1.Interfaces.Items;
using MooseEngine.Core;
using MooseEngine.Graphics;
using MooseEngine.Interfaces;
using MooseEngine.UI;
using MooseEngine.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameV1.Commands
{
    public class CommandItemIndexDrop : CommandBase
    {
        public IScene Scene { get; set; }
        public ICreature Creature { get; set; }
        public int ItemIndex { get; set; }

        public CommandItemIndexDrop(IScene scene, ICreature creature, int itemIndex)
        {
            Scene = scene;
            Creature = creature;
            ItemIndex = itemIndex;
        }

        public override NodeStates Execute()
        {
            var itemLayer = Scene.GetLayer((int)EntityLayer.Items);

            IItem? itemAtPosition = (IItem?)Scene.GetEntityAtPosition(itemLayer.Entities, Creature.Position);

            var itemAtPositionInterfaces = itemAtPosition?.GetType().GetInterfaces();
            
            var inventoryItem = Creature.Inventory.Inventory.RemoveItemFromSlotIndex(ItemIndex);

            // Does inventory item exist?
            if (inventoryItem == null)
            {
                ConsolePanel.Add($"{Creature.Name} tried to drop an item that doesn't exist.");
                ConsolePanel.Add(Creature.Inventory.Inventory.ToString());
                return NodeStates.Failure;
            }

            // Does position already contain an item?
            // If no, create a temporary container and add the item to the container.
            if (itemAtPosition == null)
            {
                // Create Temporary Container
                var tempContainer = new TemporaryContainer(8, 1000, 1000, "Pile of loot", new Coords2D(8, 7), Color.White);
                tempContainer.Position = Creature.Position;

                if(tempContainer.AddItemToFirstEmptySlot(inventoryItem) == true)
                {
                    // Attempt to add item to ItemLayer
                    itemLayer.Entities.Add(tempContainer.Position, tempContainer);
                    ConsolePanel.Add($"{Creature.Name} dropped {inventoryItem.Name}");
                    ConsolePanel.Add(Creature.Inventory.Inventory.ToString());
                    return NodeStates.Success;
                }
                else
                {
                    // Put item back into inventory
                    Creature.Inventory.Inventory.AddItemToFirstEmptySlot(inventoryItem);
                    ConsolePanel.Add($"{Creature.Name} failed to drop {inventoryItem.Name}");
                    ConsolePanel.Add(Creature.Inventory.Inventory.ToString());
                    return NodeStates.Failure;
                }

            }
            // Attempt to add item to Container
            else if (itemAtPositionInterfaces.Contains(typeof(IContainer)))
            {
                var containerAtPosition = (IContainer)itemAtPosition;
                
                if(containerAtPosition.HasEmptySlots == true)
                {
                    if (containerAtPosition.AddItemToFirstEmptySlot(inventoryItem) == true)
                    {
                        ConsolePanel.Add($"{Creature.Name} dropped {inventoryItem.Name} into {containerAtPosition.Name}");
                        ConsolePanel.Add(Creature.Inventory.Inventory.ToString());
                        return NodeStates.Success;
                    }
                }
                else
                {
                    // Put item back into inventory
                    Creature.Inventory.Inventory.AddItemToFirstEmptySlot(inventoryItem);
                    ConsolePanel.Add($"{Creature.Name} failed to drop {inventoryItem.Name}");
                    ConsolePanel.Add(Creature.Inventory.Inventory.ToString());
                    return NodeStates.Failure;
                }
            }

            return NodeStates.Success;
        }
    }
}
