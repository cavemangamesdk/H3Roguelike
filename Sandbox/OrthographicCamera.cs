using MooseEngine;
using MooseEngine.Mathematics.Matrixes;

class OrthographicCamera : ICamera
{
    public OrthographicCamera(float aspectRatio) : this(aspectRatio, 10.0f)
    {
    }

    public OrthographicCamera(float aspectRatio, float size) : this(aspectRatio, size, -1.0f, 1.0f)
    {
    }

    public OrthographicCamera(float aspectRatio, float size, float near, float far)
    {
        Projection = Matrix4.Identity;
        View = Matrix4.Identity;

        AspectRatio = aspectRatio;
        OrthographicSize = size;
        OrthographicNear = near;
        OrthographicFar = far;

        RecalculateProjection();
    }

    public Matrix4 Projection { get; set; }
    public Matrix4 View { get; set; }
    public float AspectRatio { get; }

    public float OrthographicSize { get; }
    public float OrthographicNear { get; }
    public float OrthographicFar { get; }
    private void RecalculateProjection()
    {
        float orthoLeft = -OrthographicSize * AspectRatio * 0.5f;
        float orthoRight = OrthographicSize * AspectRatio * 0.5f;
        float orthoBottom = -OrthographicSize * 0.5f;
        float orthoTop = OrthographicSize * 0.5f;

        Projection = Matrix4.Orthographic(orthoLeft, orthoRight, orthoBottom, orthoTop, OrthographicNear, OrthographicFar);
    }
}