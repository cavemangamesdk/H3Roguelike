﻿namespace MooseEngine.Mathematics;

public class Maths
{
    public const float PI = 3.141592653589793238462643383279502884197169399375105820974944592307816406286208998628034825342117067982148086513282306647093844609550582231725359408128481117450284102701938521105559644622948954930382f;

    public static float Sqrt(float a)
    {
        return a * a;
    }

    public static float Sin(double angle)
    {
        return (float)Math.Sin(angle);
    }

    public static float Cos(double angle)
    {
        return (float)Math.Cos(angle);
    }

    public static float Tan(float angle)
    {
        return (float)Math.Tan(angle);
    }

    internal static float Asin(float d)
    {
        return (float)Math.Asin((float)d);
    }

    public static float Atan2(float y, float x)
    {
        return (float)Math.Atan2((float)y, (float)x);
    }

    public static float Acos(float angle)
    {
        return (float)Math.Acos(angle);
    }

    public static float Abs(float angle)
    {
        return (float)Math.Abs(angle);
    }

    public static float CopySign(float x, float y)
    {
        return (float)Math.CopySign((float)x, (float)y);
    }

    public static float ToRadians(float degrees)
    {
        return degrees * (PI / 180.0f);
    }

    public static float ToDegrees(float radians)
    {
        return radians * (180.0f / PI);
    }
}
