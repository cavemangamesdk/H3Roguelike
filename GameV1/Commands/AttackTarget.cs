﻿using GameV1.Interfaces.Creatures;
using MooseEngine.BehaviorTree;
using MooseEngine.Core;
using MooseEngine.Interfaces;

namespace GameV1.Commands
{
    public class AttackTarget : CommandBase
    {
        public IScene Scene { get; set; }
        public ICreature Attacker { get; set; }

        public AttackTarget(IScene scene, ICreature attacker)
        {
            Scene = scene;
            Attacker = attacker;
        }

        public override NodeStates Execute()
        {
            // TODO: Check if target is in range
            if (Attacker.TargetCreature.IsDead == false)
            {
                CombatHandler.SolveAttack(Scene, Attacker, Attacker.TargetCreature, Attacker.Inventory.StrongestWeapon);
                return NodeStates.Success;
            }
            return NodeStates.Failure;
        }
    }
}
