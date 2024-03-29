﻿using GameV1.Interfaces.Weapons;
using MooseEngine.Graphics;
using MooseEngine.Interfaces;
using MooseEngine.Utilities;
using System.Numerics;

namespace GameV1.Entities.Factories
{
    public static class WeaponFactory
    {
        //public static IMeleeWeapon CreateMeleeWeapon(IEntityLayer entityLayer, Vector2 position)
        //{
        //    IDictionary<string, Coords2D> meleeWeaponSpriteCoords = new Dictionary<string, Coords2D>()
        //    {
        //        { "Club", new Coords2D(10, 3) },
        //        { "Sword", new Coords2D(6, 4) },
        //        { "Double Axe", new Coords2D(7, 4) },
        //        { "Trident", new Coords2D(10, 4) }
        //    };

        //    // check if deactivated weapon instance is available
        //    MeleeWeapon? newWeapon = entityLayer.ActivateOrCreateEntity<MeleeWeapon>(position);

        //    // IWeaopn
        //    newWeapon.Range = 1;
        //    newWeapon.CriticalChance = Randomizer.RandomInt(0, 100);
        //    newWeapon.CriticalDamage = Randomizer.RandomInt(0, 100);
        //    newWeapon.MinDamage = Randomizer.RandomInt(0, 100);
        //    newWeapon.MaxDamage = newWeapon.MinDamage + Randomizer.RandomInt(0, 100 - newWeapon.MinDamage);
        //    newWeapon.ArmorPenetrationFlat = Randomizer.RandomInt(0, 100);
        //    newWeapon.ArmorPenetrationChance = Randomizer.RandomInt(0, 100);

        //    // IEntity
        //    newWeapon.Scale = Vector2.One;
        //    newWeapon.ColorTint = Color.White;
        //    var spriteNum = Randomizer.RandomInt(0, meleeWeaponSpriteCoords.Count - 1);

        //    newWeapon.Name = meleeWeaponSpriteCoords.ElementAt(spriteNum).Key;
        //    newWeapon.SpriteCoords = meleeWeaponSpriteCoords.ElementAt(spriteNum).Value;

        //    return newWeapon;
        //}


        public static IWeapon? CreateWeapon<TWeapon>(IScene scene, int entityLayerNum, Vector2 position, params int[] collisionLayers) where TWeapon : class, IWeapon, new()
        {
            IDictionary<string, Coords2D> meleeWeaponSpriteCoords = new Dictionary<string, Coords2D>()
            {
                { "Club", new Coords2D(10, 3) },
                { "Sword", new Coords2D(6, 4) },
                { "Double Axe", new Coords2D(7, 4) },
                { "Trident", new Coords2D(10, 4) }
            };

            IDictionary<string, Coords2D> throwingWeaponSpriteCoords = new Dictionary<string, Coords2D>()
            {
                { "Throwing Knife", new Coords2D(10, 3) },
                { "Throwing Spear", new Coords2D(6, 4) },
                { "Throwing Axe", new Coords2D(7, 4) },
                { "Rock", new Coords2D(10, 4) }
            };

            IDictionary<string, Coords2D> projectileWeaponSpriteCoords = new Dictionary<string, Coords2D>()
            {
                { "Bow", new Coords2D(10, 3) },
                { "Crossbow", new Coords2D(6, 4) },
                { "Slingshot", new Coords2D(7, 4) },
                { "Blowpipe", new Coords2D(10, 4) }
            };

            var entityLayer = scene.GetLayer(entityLayerNum);

            // Is position available?
            var validPosition = scene.GetClosestValidPosition(entityLayerNum, position, collisionLayers);

            // check if deactivated weapon instance is available
            TWeapon? newWeapon = entityLayer.ActivateOrCreateEntity<TWeapon>(validPosition);

            // IEntity
            newWeapon.Scale = Vector2.One;
            newWeapon.ColorTint = Color.White;

            // randomize weapon stats, depending on weapon type
            if (newWeapon is IMeleeWeapon)
            {
                // IWeaopn
                newWeapon.Range = 1;
                newWeapon.CriticalChance = Randomizer.RandomInt(0, 100);
                newWeapon.CriticalDamage = Randomizer.RandomInt(0, 100);
                newWeapon.MinDamage = Randomizer.RandomInt(0, 100);
                newWeapon.MaxDamage = newWeapon.MinDamage + Randomizer.RandomInt(0, 100 - newWeapon.MinDamage);
                newWeapon.ArmorPenetrationFlat = Randomizer.RandomInt(0, 100);
                newWeapon.ArmorPenetrationChance = Randomizer.RandomInt(0, 100);

                var spriteNum = Randomizer.RandomInt(0, meleeWeaponSpriteCoords.Count - 1);

                newWeapon.Name = meleeWeaponSpriteCoords.ElementAt(spriteNum).Key;
                newWeapon.SpriteCoords = meleeWeaponSpriteCoords.ElementAt(spriteNum).Value;

                return newWeapon;
            }
            else if (newWeapon is IThrowingWeapon)
            {
                // IWeaopn
                newWeapon.Range = Randomizer.RandomInt(2, 4);
                newWeapon.CriticalChance = Randomizer.RandomInt(0, 100);
                newWeapon.CriticalDamage = Randomizer.RandomInt(0, 100);
                newWeapon.MinDamage = Randomizer.RandomInt(0, 100);
                newWeapon.MaxDamage = newWeapon.MinDamage + Randomizer.RandomInt(0, 100 - newWeapon.MinDamage);
                newWeapon.ArmorPenetrationFlat = Randomizer.RandomInt(0, 100);
                newWeapon.ArmorPenetrationChance = Randomizer.RandomInt(0, 100);

                var spriteNum = Randomizer.RandomInt(0, throwingWeaponSpriteCoords.Count - 1);

                newWeapon.Name = throwingWeaponSpriteCoords.ElementAt(spriteNum).Key;
                newWeapon.SpriteCoords = throwingWeaponSpriteCoords.ElementAt(spriteNum).Value;

                return newWeapon;
            }
            else if (newWeapon is IProjectileWeapon)
            {
                // IWeaopn
                newWeapon.Range = Randomizer.RandomInt(4, 8);
                newWeapon.CriticalChance = Randomizer.RandomInt(0, 100);
                newWeapon.CriticalDamage = Randomizer.RandomInt(0, 100);
                newWeapon.MinDamage = Randomizer.RandomInt(0, 100);
                newWeapon.MaxDamage = newWeapon.MinDamage + Randomizer.RandomInt(0, 100 - newWeapon.MinDamage);
                newWeapon.ArmorPenetrationFlat = Randomizer.RandomInt(0, 100);
                newWeapon.ArmorPenetrationChance = Randomizer.RandomInt(0, 100);

                var spriteNum = Randomizer.RandomInt(0, projectileWeaponSpriteCoords.Count - 1);

                newWeapon.Name = projectileWeaponSpriteCoords.ElementAt(spriteNum).Key;
                newWeapon.SpriteCoords = projectileWeaponSpriteCoords.ElementAt(spriteNum).Value;

                return newWeapon;
            }

            return null;
        }
    }
}
