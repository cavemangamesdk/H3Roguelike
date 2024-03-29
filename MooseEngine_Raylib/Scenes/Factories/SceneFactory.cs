﻿using MooseEngine.Core;
using MooseEngine.Core.Factories;
using MooseEngine.Graphics;
using MooseEngine.Interfaces;
using MooseEngine.Utilities;
using System.Numerics;

namespace MooseEngine.Scenes.Factories;

public interface ISceneFactory : IFactory
{
    IScene? Scene { get; }
    IScene CreateScene(float defaultEntityScale = Constants.DEFAULT_ENTITY_SIZE);
    void CreateCenteredCamera(Entity target);
}

public class SceneFactory : ISceneFactory
{
    public SceneFactory(IWindow window, IRenderer renderer)
    {
        Window = window;
        Renderer = renderer;
    }

    public IScene? Scene { get; private set; }
    public IWindow Window { get; }
    public IRenderer Renderer { get; }

    public IScene CreateScene(float defaultEntityScale)
    {
        return Scene ??= new Scene(Renderer, defaultEntityScale);
    }

    public void CreateCenteredCamera(Entity target)
    {
        var camera = new Camera(target, new Vector2(Window.Width / 2.0f, Window.Height / 2.0f));

        Scene.SceneCamera = camera;

        //Scene?.Add(camera);

        //return camera;
    }
}
