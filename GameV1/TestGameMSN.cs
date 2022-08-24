﻿using GameV1.Commands;
using GameV1.Commands.Factory;
using GameV1.Entities;
using GameV1.WorldGeneration;
using MooseEngine.Core;
using MooseEngine.Graphics;
using MooseEngine.Interfaces;
using MooseEngine.Scenes;
using MooseEngine.Utilities;
using System.Numerics;

namespace GameV1;

internal class TestGameMSN : IGame
{
    private IScene? _scene;
    private Player player = new Player("Hero", 120, 1000, new Coords2D(5, 0));
    private Creature monster = new Creature("Beholder", 100, 1000, new Coords2D(13, 0));
    private Weapon sword = new Weapon(100, 100, "BloodSpiller", new Coords2D(6, 4), Color.White);
    private Armor armor = new Armor(100, 100, "LifeSaver", new Coords2D(6, 4), Color.White);
    private LightSource light = new LightSource(64, new Color(255, 64, 32, 255), "Torch", new Coords2D(8, 9));

    private HashSet<Coords2D> forest = new HashSet<Coords2D>();

    public void Initialize()
    {
        var sceneFactory = Application.Instance.SceneFactory;
        _scene = sceneFactory.CreateScene();

        sceneFactory.CreateCenteredCamera(player);



        sword.MinDamage = 50;
        sword.MaxDamage = 200;
        sword.ArmorPenetrationFlat = 50;
        sword.ArmorPenetrationPercent = 20;

        armor.MinDamageReduction = 20;
        armor.MaxDamageReduction = 120;

        player.Position = new Vector2(192, 192);
        player.MainHand.Add(sword);
        //player.OffHand.Add(sword);
        player.Chest.Add(armor);

        //Console.WriteLine(player.MainHand.Item.Damage);

        _scene?.Add(player);

        monster.Position = new Vector2(-96, -96);
        monster.MainHand.Add(sword);
        monster.Chest.Add(armor);

        _scene?.Add(monster);

        light.Position = new Vector2(0, 0);
        _scene?.Add(light);


        //forest = ProceduralAlgorithms.GenerateForest(5, 30, new Coords2D(0, 0));

        // Bind key value to input value. Can be reconfigured at runtine
        InputHandler.Add(Keycode.KEY_UP, InputOptions.Up);
        InputHandler.Add(Keycode.KEY_DOWN, InputOptions.Down);
        InputHandler.Add(Keycode.KEY_LEFT, InputOptions.Left);
        InputHandler.Add(Keycode.KEY_RIGHT, InputOptions.Right);
        InputHandler.Add(Keycode.KEY_SPACE, InputOptions.Idle);

        // Multiple keys kan bind to same input
        InputHandler.Add(Keycode.KEY_W, InputOptions.Up);
        InputHandler.Add(Keycode.KEY_S, InputOptions.Down);
        InputHandler.Add(Keycode.KEY_A, InputOptions.Left);
        InputHandler.Add(Keycode.KEY_D, InputOptions.Right);

        // Multiple inputs can't bind to same key! (does nothing)
        InputHandler.Add(Keycode.KEY_W, InputOptions.Down);

        foreach (var pos in forest)
        {
            Tile tile = new Tile("Tree01", false, new Coords2D(4, 5));
            tile.Position = pos;
            tile.IsWalkable = false;
            _scene?.Add(tile);
        }


    }

    public void Uninitialize()
    {
        _scene?.Dispose();
        _scene = null;
    }

    public void Update(float deltaTime)
    {
        // Player
        InputOptions? input = InputHandler.Handle();

        ICommand command = CommandFactory.Create(input, _scene, player);

        CommandQueue.Add(command);

        // Execute Player commands
        if (!CommandQueue.IsEmpty)
        {
            Console.WriteLine("Players turn!");
            CommandQueue.Execute();

            // AI NPC / Monster / Critter controls
            AI.Execute(_scene);

            // Execute AI commands
            CommandQueue.Execute();
        }

        _scene?.UpdateRuntime(deltaTime);
    }
}