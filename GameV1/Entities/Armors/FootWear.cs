﻿using GameV1.Interfaces.Armors;
using MooseEngine.Graphics;
using MooseEngine.Utilities;

namespace GameV1.Entities.Armors
{
    public class FootWear : ArmorBase, IFootWear
    {
        public FootWear() : base()
        {
        }

        public FootWear(int durability, int maxValue, string name, Coords2D spriteCoords, Color colorTint) : base(durability, maxValue, name, spriteCoords, colorTint)
        {
        }
    }
}
