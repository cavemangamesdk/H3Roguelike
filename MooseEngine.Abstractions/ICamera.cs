using MooseEngine.Mathematics.Matrixes;

namespace MooseEngine;

public interface ICamera
{
    Matrix4 Projection { get; }
    Matrix4 View { get; }
}
