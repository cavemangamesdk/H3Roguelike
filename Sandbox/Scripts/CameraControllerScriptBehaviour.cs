using MooseEngine;
using MooseEngine.ECS.Components;
using MooseEngine.Mathematics.Vectors;

internal class CameraControllerScriptBehaviour : ScriptBehaviour
{
    private Transform? transform;
    private Vector2 velocity = Vector2.Zero;
    private float speed = 1.0f;

    public override void Start()
    {
        transform = Entity?.GetComponent<Transform>();

        Console.WriteLine("CameraScript.Start()");
    }

    public override void Stop()
    {
        Console.WriteLine("CameraScript.Stop()");
    }

    public override void Update(float deltaTime)
    {
        velocity = Vector2.Zero;

        if (Input.IsKeyPressed(Keycode.A))
        {
            velocity += -Vector2.XAxis * speed * deltaTime;
        }
        else if (Input.IsKeyPressed(Keycode.D))
        {
            velocity += Vector2.XAxis * speed * deltaTime;
        }

        if (Input.IsKeyPressed(Keycode.W))
        {
            velocity += Vector2.YAxis * speed * deltaTime;
        }
        else if (Input.IsKeyPressed(Keycode.S))
        {
            velocity += -Vector2.YAxis * speed * deltaTime;
        }

        transform.Position += velocity;
    }
}