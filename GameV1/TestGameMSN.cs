﻿using GameV1.Commands;
using GameV1.Commands.Factory;
using GameV1.Entities;
using GameV1.Entities.Armors;
using GameV1.Entities.Containers;
using GameV1.Entities.Creatures;
using GameV1.Entities.Items;
using GameV1.Entities.Weapons;
using GameV1.Interfaces.Creatures;
using GameV1.UI;
using GameV1.WorldGeneration;
using MooseEngine.BehaviorTree;
using MooseEngine.BehaviorTree.Interfaces;
using MooseEngine.Core;
using MooseEngine.Graphics;
using MooseEngine.Interfaces;
using MooseEngine.Pathfinding;
using MooseEngine.Scenes;
using MooseEngine.UI;
using MooseEngine.Utilities;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using static MooseEngine.BehaviorTree.BehaviorTreeFactory;

namespace GameV1;

public enum EntityLayer : int
{
    WalkableTiles,
    NonWalkableTiles,
    Creatures,
    Items,
    Path
}

internal class TestGameMSN : IGame
{
    public ICreature? Player { get; set; }

    private IScene? _scene;

    // Creatures
    private Creature player = new Creature("Hero", 120, new Coords2D(5, 0));
    private Creature druid = new Creature("Druid", 100, new Coords2D(9, 0));
    private Creature orc = new Creature("Orc", 100, new Coords2D(11, 0));
    public Creature guard_01 = new Creature("City guard", 100, new Coords2D(6, 0));
    public Creature guard_02 = new Creature("City guard", 100, new Coords2D(15, 0));

    // LightSources
    private LightSource light = new LightSource(8 * Constants.DEFAULT_ENTITY_SIZE, new Color(128, 128 - 48, 128 - 96, 255), 1000, 1000, "Torch", new Coords2D(9, 8), Color.White);
    private LightSource townLights = new LightSource(32 * Constants.DEFAULT_ENTITY_SIZE, new Color(128 + 32, 128 + 16, 128, 255), 1000, 1000, "Town lights", new Coords2D(9, 8), Color.White);

    // Items
    private WeaponBase sword = new MeleeWeapon(100, 10, "BloodSpiller", new Coords2D(6, 4), Color.White);
    private BodyArmor armor = new BodyArmor(100, 10, "LifeSaver", new Coords2D(6, 4), Color.White);
    private WeaponBase doubleAxe = new MeleeWeapon(100, 10, "Double Axe", new Coords2D(7, 4), Color.White);
    private WeaponBase crossBow = new ProjectileWeapon(100, 10, "Crossbow", new Coords2D(8, 4), Color.White);
    private WeaponBase trident = new MeleeWeapon(100, 10, "Trident", new Coords2D(10, 4), Color.White);

    // Inventories
    private Container weaponChest = new Container(8, 0, 0, "Weapon chest", new Coords2D(9, 3), Color.White);
    private TemporaryContainer backpack = new TemporaryContainer(8, 0, 0, "Backpack", new Coords2D(9, 3), Color.White);

    // Behavior trees
    private IList<IBehaviorTree> btrees = new List<IBehaviorTree>();

    // Layers
    private NodeMap<Tile> _nodeMap = new NodeMap<Tile>();

    private ConsolePanel _consolePanel;
    private StatsPanel _statsPanel;
    private DebugPanel _debugPanel;

    public void Initialize()
    {

        Player = player;
        
        var app = Application.Instance;
        var window = app.Window;
        var consoleSize = new Coords2D(window.Width - StatsPanel.WIDTH, ConsolePanel.HEIGHT);
        var consolePosition = new Coords2D(((window.Width - StatsPanel.WIDTH) / 2) - (consoleSize.X / 2), window.Height - consoleSize.Y);

        _consolePanel = new ConsolePanel(consolePosition, consoleSize);
        _statsPanel = new StatsPanel(Player);
        _debugPanel = new DebugPanel(10, 10, Player);


        var sceneFactory = Application.Instance.SceneFactory;
        _scene = sceneFactory.CreateScene();
        _scene.SceneCamera = new Camera(Player, new Vector2((window.Width - StatsPanel.WIDTH) / 2.0f, (window.Height - consoleSize.Y) / 2.0f));



        sword.MinDamage = 5;
        sword.MaxDamage = 20;
        sword.ArmorPenetrationFlat = 5;
        sword.ArmorPenetrationPercent = 2;

        armor.DamageReduction = 50;



        // Spawn world
        WorldGenerator.GenerateWorld(80085, ref _scene);

        var itemLayer = _scene.AddLayer<Item>(EntityLayer.Items);
        var creatureLayer = _scene.AddLayer<Creature>(EntityLayer.Creatures);



        // Spawn weapons
        doubleAxe.Position = new Vector2(63, 42) * Constants.DEFAULT_ENTITY_SIZE;
        itemLayer?.Add(doubleAxe);
        crossBow.Position = new Vector2(64, 43) * Constants.DEFAULT_ENTITY_SIZE;
        itemLayer?.Add(crossBow);
        trident.Position = new Vector2(66, 47) * Constants.DEFAULT_ENTITY_SIZE;
        itemLayer?.Add(trident);

        // Spawn containers
        weaponChest.Position = new Vector2(55, 28) * Constants.DEFAULT_ENTITY_SIZE;
        itemLayer?.Add(weaponChest);

        backpack.Position = new Vector2(55, 26) * Constants.DEFAULT_ENTITY_SIZE;
        backpack.AddItemToFirstEmptySlot(new MeleeWeapon(100, 10, "Double Axe", new Coords2D(7, 4), Color.White));
        backpack.AddItemToFirstEmptySlot(new ProjectileWeapon(100, 10, "Crossbow", new Coords2D(8, 4), Color.White));
        backpack.AddItemToFirstEmptySlot(new MeleeWeapon(100, 10, "Trident", new Coords2D(10, 4), Color.White));
        itemLayer?.Add(backpack);

        // Spawn player
        player.Position = new Vector2(51, 51) * Constants.DEFAULT_ENTITY_SIZE;
        //player.Inventory.
        player.Inventory.PrimaryWeapon.Add(sword);
        player.Inventory.BodyArmor.Add(armor);
        creatureLayer?.Add(player);

        orc.Position = new Vector2(52, 50) * Constants.DEFAULT_ENTITY_SIZE;
        //player.Inventory.
        orc.Inventory.PrimaryWeapon.Add(sword);
        orc.Inventory.BodyArmor.Add(armor);
        _scene.TryPlaceEntity((int)EntityLayer.Creatures, orc, orc.Position);

        // Light sources
        light.Position = new Vector2(57, 29) * Constants.DEFAULT_ENTITY_SIZE;
        itemLayer?.Add(light);

        townLights.Position = new Vector2(51, 50) * Constants.DEFAULT_ENTITY_SIZE;
        itemLayer?.Add(townLights);

        for (int i = 0; i < 128; i++)
        {
            // Color(128, 128 - 48, 128 - 96, 255)
            var color = new Color(
                128 + Randomizer.RandomInt(-96, 96),
                128 + Randomizer.RandomInt(-96, 96),
                128 + Randomizer.RandomInt(-96, 96), 255);
            var light = new LightSource(Randomizer.RandomInt(2, 32) * Constants.DEFAULT_ENTITY_SIZE, color, 1000, 100, "Camp fire", new Coords2D(9, 8), Color.White);
            light.Position = new Vector2(Randomizer.RandomInt(0, 500), Randomizer.RandomInt(0, 500)) * Constants.DEFAULT_ENTITY_SIZE;
            //itemLayer?.Add(light);
            _scene.TryPlaceEntity((int)EntityLayer.Items, light, light.Position);
        }

        // Druid chasing player
        druid.Position = new Vector2(85, 38) * Constants.DEFAULT_ENTITY_SIZE;
        druid.Inventory.PrimaryWeapon.Add(sword);
        druid.Inventory.BodyArmor.Add(armor);
        druid.Stats.Perception = 8 * Constants.DEFAULT_ENTITY_SIZE;
        creatureLayer?.Add(druid);

        // Randomized walk guard
        guard_02.Position = new Vector2(51, 41) * Constants.DEFAULT_ENTITY_SIZE;
        guard_02.Inventory.PrimaryWeapon.Add(sword);
        guard_02.Inventory.BodyArmor.Add(armor);
        creatureLayer?.Add(guard_02);

        // Patrolling guard
        guard_01.Position = new Vector2(40, 40) * Constants.DEFAULT_ENTITY_SIZE;
        guard_01.Inventory.PrimaryWeapon.Add(sword);
        guard_01.Inventory.BodyArmor.Add(armor);
        guard_01.Stats.Perception = 3 * Constants.DEFAULT_ENTITY_SIZE;
        creatureLayer?.Add(guard_01);


        var walkableTileLayer = (IEntityLayer<Tile>)_scene.GetLayer((int)EntityLayer.WalkableTiles);

        _scene.PathMap = _nodeMap.GenerateMap(walkableTileLayer);


        // Randomized walk guard Behavior tree
        var guard02Node = Serializer(
                Action(new CommandPatrolRectangularArea(
                    _scene,
                    guard_02,
                    light.Position + new Vector2(-4, -4) * Constants.DEFAULT_ENTITY_SIZE,
                    light.Position + new Vector2(4, 4) * Constants.DEFAULT_ENTITY_SIZE
                    )),
                Delay(
                    Action(new CommandIdle()),
                    2)
                );

        var guard_02Tree = BehaviorTree(guard_02, guard02Node);

        btrees.Add(guard_02Tree);

        //Druid behavior tree
        //Roam around randomly in a part of the map
        //Follow creatures while inside perception range
        // Attack when standing beside creature
        // When no creatures within range, go back to roaming
        var druidNode = Selector(
                Serializer(
                        Action(new CommandTargetCreatureWithinRange(_scene, druid)),
                        Action(new CommandMoveToTarget(_scene, druid)),
                        Action(new CommandAttackTarget(_scene, druid))
                    ),
                Action(new CommandPatrolCircularArea(_scene, druid, druid.Position, 8 * Constants.DEFAULT_ENTITY_SIZE))

            );

        var druidTree = BehaviorTree(druid, druidNode);

        btrees.Add(druidTree);

        // Patrolling town guard
        //var guard01Node = SerializerTurnBased(
        //        SerializerTurnBased(
        //            Action(new CommandMoveLeft(_scene, guard_01)),
        //            Action(new CommandMoveUp(_scene, guard_01)),
        //            Action(new CommandMoveRight(_scene, guard_01)),
        //            Action(new CommandMoveDown(_scene, guard_01))),
        //        Action(new CommandMoveRight(_scene, guard_01))
        //    );

        var attackPatternNode = SerializerTurnBased(
                        Action(new CommandAttackTarget(_scene, guard_01)),
                        Action(new CommandAttackTarget(_scene, guard_01)),
                        Action(new CommandBlock(_scene, guard_01))
                    );

        var guard01Node = Selector(
                Serializer(
                    Action(new CommandTargetCreatureWithinRange(_scene, guard_01)),
                    Action(new CommandMoveToTarget(_scene, guard_01)),
                    attackPatternNode
                ),
                Serializer(
                    Action(new CommandMoveToPosition(_scene, guard_01, new Vector2(40, 44) * Constants.DEFAULT_ENTITY_SIZE)),
                    Action(new CommandMoveToPosition(_scene, guard_01, new Vector2(62, 44) * Constants.DEFAULT_ENTITY_SIZE)),
                    Action(new CommandMoveToPosition(_scene, guard_01, new Vector2(62, 57) * Constants.DEFAULT_ENTITY_SIZE)),
                    Action(new CommandMoveToPosition(_scene, guard_01, new Vector2(40, 57) * Constants.DEFAULT_ENTITY_SIZE))
                )
            );

        var guard_01Tree = BehaviorTree(guard_01, guard01Node);

        btrees.Add(guard_01Tree);

        // Key bindings
        InputHandler.Add(Keycode.KEY_UP, InputOptions.Up);
        InputHandler.Add(Keycode.KEY_DOWN, InputOptions.Down);
        InputHandler.Add(Keycode.KEY_LEFT, InputOptions.Left);
        InputHandler.Add(Keycode.KEY_RIGHT, InputOptions.Right);
        InputHandler.Add(Keycode.KEY_SPACE, InputOptions.Idle);
        InputHandler.Add(Keycode.KEY_I, InputOptions.ItemPickUp);
        InputHandler.Add(Keycode.KEY_Q, InputOptions.ItemDrop);
        InputHandler.Add(Keycode.KEY_ZERO, InputOptions.Zero);
        InputHandler.Add(Keycode.KEY_ONE, InputOptions.One);
        InputHandler.Add(Keycode.KEY_TWO, InputOptions.Two);
        InputHandler.Add(Keycode.KEY_THREE, InputOptions.Three);
        InputHandler.Add(Keycode.KEY_FOUR, InputOptions.Four);
        InputHandler.Add(Keycode.KEY_FIVE, InputOptions.Five);
        InputHandler.Add(Keycode.KEY_SIX, InputOptions.Six);
        InputHandler.Add(Keycode.KEY_SEVEN, InputOptions.Seven);
        InputHandler.Add(Keycode.KEY_EIGHT, InputOptions.Eight);
        InputHandler.Add(Keycode.KEY_NINE, InputOptions.Nine);

    }

    public void Uninitialize()
    {
        _scene?.Dispose();
        _scene = null;
    }

    public void Update(float deltaTime)
    {
        // Player input
        var input = InputHandler.Handle();

        // Generate commands
        ICommand? command = CommandFactory.Create(input, _scene, Player);

        CommandQueue.Add(command);

        if (!CommandQueue.IsEmpty)
        {
            // Execute Player commands
            CommandQueue.Execute();

            foreach (var entity in _scene.GetLayer((int)EntityLayer.Creatures).Entities)
            {
                ICreature creature = (ICreature)entity.Value;

                if (creature.IsDead == true)
                {
                    CombatHandler.KillCreature(_scene.GetLayer((int)EntityLayer.Creatures), creature, _scene.GetLayer((int)EntityLayer.Items));
                }
            }

            // AI NPC / Monster / Critter controls
            foreach (BTree btree in btrees)
            {
                btree.Evaluate();

                foreach (var entity in _scene.GetLayer((int)EntityLayer.Creatures).Entities)
                {
                    ICreature creature = (ICreature)entity.Value;

                    if (creature.IsDead == true)
                    {
                        CombatHandler.KillCreature(_scene.GetLayer((int)EntityLayer.Creatures), creature, _scene.GetLayer((int)EntityLayer.Items));
                    }
                }
            }
        }

        // TODO: Only illuminate if range within viewport, AABB check
        // Dynamically updated light sources
        var windowSize = new Vector2(
            (int)(Application.Instance.Window.Width * 0.5 - (Application.Instance.Window.Width * 0.5 % Constants.DEFAULT_ENTITY_SIZE)),
            (int)(Application.Instance.Window.Height * 0.5 - (Application.Instance.Window.Height * 0.5 % Constants.DEFAULT_ENTITY_SIZE)));
        var cameraPosition = _scene.SceneCamera.Position;
        var itemLayer = _scene.GetLayer((int)EntityLayer.Items);
        var lightSources = _scene.GetEntitiesOfType<LightSource>(itemLayer);

        foreach (LightSource lightSource in lightSources.Values)
        {
            var isOverlapping = MathFunctions.IsOverlappingAABB(
                cameraPosition,
                windowSize,
                lightSource.Position,
                new Vector2(lightSource.Range, lightSource.Range));

            if (isOverlapping)
            {
                lightSource.Illuminate(_scene);
            }
        }

        _scene?.UpdateRuntime(deltaTime);
    }

    public void UIRender(IUIRenderer UIRenderer)
    {
        UIRenderer.DrawFPS(16, 16);

        _consolePanel.OnGUI(UIRenderer);
        _statsPanel.OnGUI(UIRenderer);
        _debugPanel.OnGUI(UIRenderer);
    }
}