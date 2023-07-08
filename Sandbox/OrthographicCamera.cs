using MooseEngine;
using MooseEngine.Mathematics.Matrixes;

internal enum ProjectionType
{
    Perspective,
    Orthographic
}

internal abstract class CameraBase : ICamera
{
    private ProjectionType projectionType;

    public CameraBase(ProjectionType projectionType)
    {
        ProjectionType = projectionType;
    }

    public ProjectionType ProjectionType
    {
        get { return projectionType; }
        set
        {
            projectionType = value;
            RecalculateProjection();
        }
    }
    public float AspectRatio { get; set; }

    public float OrthographicSize { get; set; }
    public float OrthographicNear { get; set; }
    public float OrthographicFar { get; set; }

    public Matrix4 Projection { get; set; }
    public Matrix4 View { get; set; }

    public void SetViewport(int width, int height)
    {
        AspectRatio = (float)width / (float)height;
        RecalculateProjection();
    }

    protected void RecalculateProjection()
    {
        if (ProjectionType == ProjectionType.Perspective)
        {
            return;
        }

        float orthoLeft = -OrthographicSize * AspectRatio * 0.5f;
        float orthoRight = OrthographicSize * AspectRatio * 0.5f;
        float orthoBottom = -OrthographicSize * 0.5f;
        float orthoTop = OrthographicSize * 0.5f;

        Projection = Matrix4.Orthographic(orthoLeft, orthoRight, orthoBottom, orthoTop, OrthographicNear, OrthographicFar);
    }
}

class OrthographicCamera : CameraBase
{
    public OrthographicCamera(float size) : this(size, -1.0f, 1.0f)
    {
    }

    public OrthographicCamera(float size, float near, float far)
        : base(ProjectionType.Orthographic)
    {
        Projection = Matrix4.Identity;
        View = Matrix4.Identity;

        OrthographicSize = size;
        OrthographicNear = near;
        OrthographicFar = far;

        RecalculateProjection();
    }
}