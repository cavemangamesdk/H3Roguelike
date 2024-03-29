﻿using System.Runtime.InteropServices;

namespace MooseEngine.Mathematics.Vectors;

[StructLayout(LayoutKind.Sequential)]
public struct Vector4 : IEquatable<Vector4>
{
    public Vector4()
    {
        X = default;
        Y = default;
        Z = default;
        W = default;
    }

    public Vector4(float scalar)
    {
        X = scalar;
        Y = scalar;
        Z = scalar;
        W = scalar;
    }

    public Vector4(float x, float y, float z, float w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }

    public float X;
    public float Y;
    public float Z;
    public float W;

    public static Vector4 Zero => new(0.0f, 0.0f, 0.0f, 0.0f);
    public static Vector4 One => new(1.0f, 1.0f, 1.0f, 1.0f);

    public static Vector4 XAxis => new(1.0f, 0.0f, 0.0f, 0.0f);
    public static Vector4 YAxis => new(0.0f, 1.0f, 0.0f, 0.0f);
    public static Vector4 ZAxis => new(0.0f, 0.0f, 1.0f, 0.0f);
    public static Vector4 WAxis => new(0.0f, 0.0f, 0.0f, 1.0f);

    public float Length => Maths.Sqrt(X * X + Y * Y + Z * Z + W * W);

    public Vector4 Normalize()
    {
        var scale = 1.0f / Length;

        X *= scale;
        Y *= scale;
        Z *= scale;
        W *= scale;

        return this;
    }

    #region Static vector math methods
    public static Vector4 Lerp(Vector4 a, Vector4 b, float time)
    {
        a.X = time * (b.X - a.X) + a.X;
        a.Y = time * (b.Y - a.Y) + a.Y;
        a.Z = time * (b.Z - a.Z) + a.Z;
        a.W = time * (b.W - a.W) + a.W;

        return a;
    }

    public static float Dot(Vector4 left, Vector4 right)
    {
        return left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
    }
    #endregion

    #region Operators
    public static Vector4 operator +(Vector4 left, Vector4 right)
    {
        var result = new Vector4
        {
            X = left.X + right.X,
            Y = left.Y + right.Y,
            Z = left.Z + right.Z,
            W = left.W + right.W
        };

        return result;
    }

    public static Vector4 operator -(Vector4 left, Vector4 right)
    {
        var result = new Vector4
        {
            X = left.X - right.X,
            Y = left.Y - right.Y,
            Z = left.Z - right.Z,
            W = left.W - right.W
        };

        return result;
    }

    public static Vector4 operator *(Vector4 left, Vector4 right)
    {
        var result = new Vector4
        {
            X = left.X * right.X,
            Y = left.Y * right.Y,
            Z = left.Z * right.Z,
            W = left.W * right.W
        };

        return result;
    }

    public static Vector4 operator /(Vector4 left, Vector4 right)
    {
        var result = new Vector4
        {
            X = left.X / right.X,
            Y = left.Y / right.Y,
            Z = left.Z / right.Z,
            W = left.W / right.W
        };

        return result;
    }

    public static bool operator ==(Vector4 left, Vector4 right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Vector4 left, Vector4 right)
    {
        return !(left == right);
    }
    #endregion

    public override bool Equals(object? obj)
    {
        return obj is Vector4 vector && Equals(vector);
    }

    public bool Equals(Vector4 other)
    {
        return X == other.X && Y == other.Y && Z == other.Z && W == other.W;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, Z, W);
    }
}
