﻿using MooseEngine.Interfaces;
using MooseEngine.Utilities;
using Raylib_cs;
using System.Numerics;

namespace MooseEngine.Scenes;

public class Camera : Entity, ISceneCamera
{
    private Camera2D _raylibCamera;
    private readonly Entity _targetEntity;

    public Camera(Entity target, Vector2 offset, float zoom = 1.0f) : base("Camera", new Coords2D(27,27))
    {
        _targetEntity = target;

        _raylibCamera = new Camera2D
        {
            target = _targetEntity.Position,
            offset = offset,
            zoom = zoom,
            rotation = 0.0f
        };
    }

    public Camera2D RaylibCamera { get { return _raylibCamera; } }

    public override void Initialize()
    {
    }

    public override void Update(float deltaTime)
    {
        _raylibCamera.target = _targetEntity.Position;
        Position = _targetEntity.Position;
    }
}