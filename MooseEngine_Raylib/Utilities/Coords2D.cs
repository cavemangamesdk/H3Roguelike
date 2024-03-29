﻿using Raylib_cs;
using System.Numerics;

namespace MooseEngine.Utilities
{
    public struct Coords2D
    {
        public int X { get; init; }
        public int Y { get; init; }

        public Coords2D Up { get { return new Coords2D(0, -1); } }
        public Coords2D Down { get { return new Coords2D(0, 1); } }
        public Coords2D Left { get { return new Coords2D(-1, 0); } }
        public Coords2D Right { get { return new Coords2D(1, 0); } }


        public Coords2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Coords2D(Rectangle rectangle)
        {
            X = (int)rectangle.x;
            Y = (int)rectangle.y;
        }

        public Coords2D(Vector2 vector)
        {
            X = (int)vector.X;
            Y = (int)vector.Y;
        }

        public static Coords2D operator +(Coords2D a, Coords2D b)
        {
            return new Coords2D(a.X + b.X, a.Y + b.Y);
        }

        public static Coords2D operator -(Coords2D a, Coords2D b)
        {
            return new Coords2D(a.X - b.X, a.Y - b.Y);
        }

        public static Coords2D operator *(Coords2D a, int b)
        {
            return new Coords2D(a.X * b, a.Y * b);
        }

        public static implicit operator Vector2(Coords2D v)
        {
            return new Vector2(v.X, v.Y);
        }

        public static implicit operator Coords2D(Vector2 v)
        {
            return new Coords2D((int)v.X, (int)v.Y);
        }
    }
}