﻿using MooseEngine.Pathfinding;
using MooseEngine.Utilities;
using System.Numerics;

namespace MooseEngine.Interfaces;

public interface IScene : IDisposable
{
    ISceneCamera SceneCamera { get; set; }
    IDictionary<int, IEntityLayer> EntityLayers { get; set; }
    Pathfinder Pathfinder { get; set; }
    PathMap PathMap { get; set; }

    bool TryMoveEntity(int entityLayer, IEntity entity, Vector2 targetPosition, params int[] collisionLayers);
    bool TryPlaceEntity(int entityLayer, IEntity entity, Vector2 targetPosition, params int[] collisionLayers);
    IDictionary<Vector2, TEntity>? GetEntitiesOfType<TEntity>(IEntityLayer entities) where TEntity : class, IEntity;
    IEntity? GetEntityAtPosition(IDictionary<Vector2, IEntity> Tiles, Vector2 position);
    Vector2 GetRandomValidPosition(IDictionary<Vector2, IEntity> entities);
    Vector2 GetClosestValidPosition(int entityLayer, Vector2 targetPosition, params int[] collisionLayers);
    IDictionary<Vector2, IEntity>? GetEntitiesWithinCircle(IDictionary<Vector2, IEntity> entities, Coords2D position, int distance);
    IDictionary<Vector2, TEntity>? GetEntitiesWithinCircle<TEntity>(IDictionary<Vector2, IEntity> entities, Coords2D position, int distance) where TEntity : class, IEntity;
    //IList<IEntity>? GetEntitiesWithinCircle(IDictionary<Vector2, IEntity> entities, Coords2D position, int distance);
    IDictionary<Vector2, IEntity>? GetEntitiesWithinRectangle(IDictionary<Vector2, IEntity> entities, Vector2 topLeft, Vector2 bottomRight);

    IEntityLayer<TEntity> AddLayer<TEntity>(int layer) where TEntity : class, IEntity;
    IEntityLayer GetLayer(int layer);

    void UpdateRuntime(float deltaTime);
}
