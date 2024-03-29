﻿using MooseEngine.BehaviorTree;
using MooseEngine.Core;
using MooseEngine.Interfaces;

namespace GameV1.Commands
{
    public class BlockAttack : CommandBase
    {
        public IScene Scene { get; set; }

        public IEntity Entity { get; set; }

        public BlockAttack(IScene scene, IEntity entity)
        {
            Scene = scene;
            Entity = entity;
        }

        public override NodeStates Execute()
        {
            return NodeStates.Success;
        }
    }
}
