﻿using GameV1.Entities;
using GameV1.Interfaces;
using MooseEngine.Interfaces;
using MooseEngine.Scenes;
using MooseEngine.UI;
using MooseEngine.Utilities;

namespace GameV1
{
    public static class CombatHandler
    {
        public static void SolveAttack(ICreature attacker, ICreature defender, IWeapon attackWeapon)
        {
            int damage = attacker.Stats.Strength + attackWeapon.Damage;
            //int damage = (int)(attacker.Stats.Strength + attacker.StrongestWeapon.Damage);
            float damageModifier = 100.0f / (100.0f + (defender.Inventory.BodyArmor.Item.DamageReduction * (1.0f - (attackWeapon.ArmorPenetrationPercent / 100.0f)) - attackWeapon.ArmorPenetrationFlat));
            defender.Stats.Health -= (int)(damage * damageModifier);

            //Console.WriteLine($"Damage: {damage}, Damage modifier: {damageModifier}");
            ConsolePanel.Add($"Damage: {damage}, Damage modifier: {damageModifier} (health left: {defender.Stats.Health})");
        }

        public static void KillCreature(IEntityLayer creatureLayer, ICreature creature, IEntityLayer replacementLayer)
        {
            // Check if entíty exists at position
            if(creatureLayer.Entities.ContainsKey(creature.Position) == false) { return; }

            // Create Inventory item
            var lootableCorpse = new Inventory(8, 1000, 1000, $"{creature.Name}'s corpse", new Coords2D(8, 7));
            lootableCorpse.Position = creature.Position;
            
            // Add lootable content from dead creature
            creature.Inventory.Inventory.MoveContainerContent(lootableCorpse);

            // Remove Creature from entity layer
            creatureLayer.Entities.Remove(creature.Position);
            // Add inventory to item layer.
            replacementLayer.Entities.Add(lootableCorpse.Position, lootableCorpse);
        }
    }
}
