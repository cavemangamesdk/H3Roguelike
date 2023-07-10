using MooseEngine.Mathematics.Matrixes;

namespace MooseEngine.ECS.Components;

public sealed class Camera : ComponentBase
{
    public SceneCamera SceneCamera { get; set; } = new SceneCamera();
    public bool IsPrimary { get; set; } = true;
}

public enum ProjectionType { Perspective = 0, Orthographic = 1 };

public sealed class SceneCamera : ICamera
{
    private float orthographicSize = 10.0f;
    private float orthographicNear = -1.0f;
    private float orthographicFar = 1.0f;

    private float perspectiveFieldOfView = 10.0f;
    private float perspectiveNear = 0.01f;
    private float perspectiveFar = 1000.0f;

    private float aspectRatio = 0.0f;

    public SceneCamera()
    {
        RecalculateProjection();
    }

    public ProjectionType ProjectionType { get; set; }

    public float OrthographicSize
    {
        get => orthographicSize;
        set
        {
            orthographicSize = value;
            RecalculateProjection();
        }
    }
    public float OrthographicNear
    {
        get => orthographicNear;
        set
        {
            orthographicNear = value;
            RecalculateProjection();
        }
    }
    public float OrthographicFar
    {
        get => orthographicFar;
        set
        {
            orthographicFar = value;
            RecalculateProjection();
        }
    }

    public float PerspectiveFieldOfView
    {
        get => perspectiveFieldOfView;
        set
        {
            perspectiveFieldOfView = value;
            RecalculateProjection();
        }
    }
    public float PerspectiveNear
    {
        get => perspectiveNear;
        set
        {
            perspectiveNear = value;
            RecalculateProjection();
        }
    }
    public float PerspectiveFar
    {
        get => perspectiveFar;
        set
        {
            perspectiveFar = value;
            RecalculateProjection();
        }
    }

    public Matrix4 Projection { get; internal set; }
    public Matrix4 View { get; set; } = Matrix4.Identity;

    public void SetPerspective(float verticalFieldOfView, float near, float far)
    {
        ProjectionType = ProjectionType.Perspective;
        perspectiveFieldOfView = verticalFieldOfView;
        perspectiveNear = near;
        perspectiveFar = far;
        RecalculateProjection();
    }

    public void SetOrthographic(float size, float near, float far)
    {
        ProjectionType = ProjectionType.Orthographic;
        orthographicSize = size;
        orthographicNear = near;
        orthographicFar = far;
        RecalculateProjection();
    }

    public void SetViewport(int width, int height)
    {
        aspectRatio = (float)width / (float)height;
        RecalculateProjection();
    }

    private void RecalculateProjection()
    {
        if (ProjectionType == ProjectionType.Perspective)
        {
            Projection = Matrix4.Perspective(PerspectiveFieldOfView, aspectRatio, PerspectiveNear, PerspectiveFar);
        }
        else
        {
            float orthoLeft = -OrthographicSize * aspectRatio * 0.5f;
            float orthoRight = OrthographicSize * aspectRatio * 0.5f;
            float orthoBottom = -OrthographicSize * 0.5f;
            float orthoTop = OrthographicSize * 0.5f;

            Projection = Matrix4.Orthographic(orthoLeft, orthoRight, orthoBottom, orthoTop, OrthographicNear, OrthographicFar);
        }
    }
}