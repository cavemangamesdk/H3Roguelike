﻿using GameV1.Interfaces.Armors;
using MooseEngine.Graphics;
using MooseEngine.Utilities;

namespace GameV1.Entities.Armors
{
    public class BodyArmor : ArmorBase, IBodyArmor
    {

        public BodyArmor() : base()
        {

        }

        public BodyArmor(int durability, int maxValue, string name, Coords2D spriteCoords, Color colorTint)
            : base(durability, maxValue, name, spriteCoords, colorTint)
        {
        }

    }
}
