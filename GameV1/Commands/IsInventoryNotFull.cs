﻿using GameV1.Interfaces.Creatures;
using MooseEngine.BehaviorTree;
using MooseEngine.Core;
using MooseEngine.Interfaces;

namespace GameV1.Commands
{
    public class IsInventoryNotFull : CommandBase
    {
        public IScene Scene { get; set; }
        public ICreature Creature { get; set; }

        public IsInventoryNotFull(IScene scene, ICreature creature)
        {
            Scene = scene;
            Creature = creature;
        }

        public override NodeStates Execute()
        {
            var doesInventoryHaveEmptySlots = Creature.Inventory.Inventory.HasEmptySlots;

            // Console.WriteLine($"Does {Creature.Name} inventory have empty slots? " + doesInventoryHaveEmptySlots);

            switch (doesInventoryHaveEmptySlots)
            {
                case true:
                    // Console.WriteLine("IsInventoryNotFull returns Success");
                    return NodeStates.Success;
                case false:
                    // Console.WriteLine("IsInventoryNotFull returns Failure");
                    return NodeStates.Failure;
            }
        }
    }
}
