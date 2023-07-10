using MooseEngine.Mathematics.Matrixes;
using MooseEngine.Mathematics.Vectors;

namespace MooseEngine.ECS.Component;

public sealed class Transform : ComponentBase
{
    public Transform()
        : this(Vector3.Zero, Vector3.Zero, Vector3.One)
    {
    }

    public Transform(Vector3 position, Vector3 rotation, Vector3 scale)
    {
        Position = position;
        Rotation = rotation;
        Scale = scale;

    }

    public Vector3 Position { get; set; }
    public Vector3 Rotation { get; set; }
    public Vector3 Scale { get; set; }

    public Matrix4 GetTransform()
    {
        return Matrix4.Translate(Position) * Matrix4.Rotate(Rotation) * Matrix4.Scale(Scale);
    }
}
