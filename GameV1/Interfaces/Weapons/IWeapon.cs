﻿using GameV1.Interfaces.Items;

namespace GameV1.Interfaces.Weapons
{
    public interface IWeapon : IOrdnance
    {
        int Range { get; set; }
        int CriticalChance { get; set; }
        int CriticalDamage { get; set; }
        int MinDamage { get; set; }
        int MaxDamage { get; set; }
        int ArmorPenetrationFlat { get; set; }
        int ArmorPenetrationChance { get; set; }

        int Damage { get; }
        int AverageDamage { get; }
        

        int DoDamage();
    }
}
