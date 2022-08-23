﻿using GameV1.Interfaces;
using MooseEngine;
using MooseEngine.Core;
using MooseEngine.Scenes;
using System.Numerics;

namespace GameV1.Commands
{
    public class CommandMoveUp : Command
    {

        public CommandMoveUp(Scene scene, Entity entity) : base(scene, entity)
        {
        }

        public override void Execute()
        {
            Entity.Position += new Vector2(0, -Constants.DEFAULT_ENTITY_SIZE);
        }
    }
}