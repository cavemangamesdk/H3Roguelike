using MooseEngine.Mathematics.Vectors;

namespace MooseEngine.Mathematics;

public static class Vector3Extensions
{
    public static float[] ToFloatArray(this Vector3 vector)
    {
        var result = new float[3]
        {
            vector.X, vector.Y, vector.Z
        };
        return result;
    }
}
