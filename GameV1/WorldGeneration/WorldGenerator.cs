﻿using GameV1.Entities;
using MooseEngine.Graphics;
using MooseEngine.Scenes;
using MooseEngine.Utilities;
using System.Numerics;

namespace GameV1.WorldGeneration
{
    public static class WorldGenerator
    {
        private static World? world;
        private static Dictionary<Coords2D, float> _overWorld = new Dictionary<Coords2D, float>();
        private static Dictionary<Coords2D, HashSet<Coords2D>> _forestPositions = new Dictionary<Coords2D, HashSet<Coords2D>>();
        private static Dictionary<Coords2D, int> _castlePositions = new Dictionary<Coords2D, int>();

        private static List<List<StructureData>> _castleSmallData = new List<List<StructureData>>();
        private static List<List<StructureData>> _castleMediumData = new List<List<StructureData>>();
        private static List<List<StructureData>> _castleLargeData = new List<List<StructureData>>();
        private static List<List<StructureData>> _graveyardMediumData = new List<List<StructureData>>();

        private static List<List<StructureData>> _startVillageData = new List<List<StructureData>>();

        private static Coords2D[] _grassTilesCoords = new Coords2D[3]{new Coords2D(5, 4),
                                                                     new Coords2D(4, 10),
                                                                     new Coords2D(5, 10)};

        private static int _clearDistanceToStarterVillage = 450;
        private static bool _placePOI = true;

        //TODO We need to get scene out of param, perhaps make GenerateWorld return a map of sort.
        public static bool GenerateWorld(int seed, ref IScene scene) 
        {
            world = new World(1001,1001,seed,new Coords2D(51*Constants.DEFAULT_ENTITY_SIZE,51 * Constants.DEFAULT_ENTITY_SIZE));
            
            _overWorld = ProceduralAlgorithms.GeneratePerlinNoiseMap(world.WorldWidth, world.WorldHeight, Constants.DEFAULT_ENTITY_SIZE, world.WorldSeed);

            _castleSmallData = StructureCreator.LoadStructure(@"..\..\..\Resources\CSV\Castle01.csv");
            _castleMediumData = StructureCreator.LoadStructure(@"..\..\..\Resources\CSV\Castle02.csv");
            _castleLargeData = StructureCreator.LoadStructure(@"..\..\..\Resources\CSV\Castle03.csv");

            _startVillageData = StructureCreator.LoadStructure(@"..\..\..\Resources\CSV\StarterVillage.csv");

            #region Generate Grass
            foreach (var tile in _overWorld)
            {
                //Generate grass with perlin noise...
                if (tile.Value > -0.3 && tile.Value < 0.3)
                {
                    var rand = Randomizer.RandomInt(0, 3);
                    var coord = _grassTilesCoords[rand];

                    var tintColor = CalculateTint(tile.Key);
                    Tile grass = new Tile("Grass", true, coord, tintColor);
                    grass.Position = new Vector2(tile.Key.X, tile.Key.Y);
                    world.AddTile(tile.Key, grass);
                }
                else
                {
                    var tintColor = CalculateTint(tile.Key);
                    Tile grass = new Tile("Grass", true, new Coords2D(1,1), tintColor);
                    grass.Position = new Vector2(tile.Key.X, tile.Key.Y);
                    world.AddTile(tile.Key, grass);
                }
            }
            #endregion

            foreach (var tile in _overWorld)
            {
                //Place forests...

                if (tile.Value > 0.3 && tile.Value < 0.305)
                {
                    var dist = Vector2.Distance(new Vector2(tile.Key.X, tile.Key.Y),new Vector2(world.StartPos.X,world.StartPos.Y));
                    if (dist > _clearDistanceToStarterVillage)
                    {
                        var forest = new HashSet<Coords2D>();
                        forest = ProceduralAlgorithms.GenerateForest(75, 5, tile.Key);
                        _forestPositions.Add(tile.Key, forest);
                    }
                }

                //Place Castles...
                if (tile.Value > -0.2 && tile.Value < 0.2)
                {
                    foreach (var castles in _castlePositions)
                    {
                        var dist = Vector2.Distance(new Vector2(castles.Key.X, castles.Key.Y), new Vector2(tile.Key.X,tile.Key.Y));
                        if (dist < 1500)
                        {
                            _placePOI = false;
                        }
                    }

                    if (_placePOI == true)
                    {
                        _castlePositions.Add(tile.Key, Randomizer.RandomInt(0,3));
                    }

                    _placePOI = true;
                }

                #region Visualize Perlin Noise
                //Visualize PerlinNoise, used for debugging...
                //float val = MathFunctions.InverseLerp(-1, 1, tile.Value);
                //int colorVal = (int)MathFunctions.Lerp(0, 255, val);
                //Color tintColor = new Color(colorVal, colorVal, colorVal, 255);
                //Tile perlinTile = new Tile("Perlin", true, new Coords2D(3, 10), tintColor);
                //perlinTile.Scale = new Vector2(Constants.DEFAULT_ENTITY_SIZE, Constants.DEFAULT_ENTITY_SIZE);
                //perlinTile.Position = new Vector2(tile.Key.X, tile.Key.Y);
                //scene?.Add(perlinTile);
                #endregion
            }

            //Generate tiles...

            foreach (var forest in _forestPositions)
            {
                foreach(var tree in forest.Value)
                {
                    var colorTint = CalculateTint(tree);
                    Tile treeTile = new Tile("Tree01", false, new Coords2D(4, 5), colorTint);
                    treeTile.Position = new Vector2(tree.X, tree.Y);
                    world.AddTile(tree, treeTile);
                }
            }

            //Creating tiles for castles...
            foreach (var castle in _castlePositions)
            {
                var castlePosition = castle.Key;
                var castleIndex = castle.Value;
                var castleData = new List<List<StructureData>>();

                switch (castleIndex)
                {
                    case 0: castleData = _castleSmallData;  break;
                    case 1: castleData = _castleMediumData; break;
                    case 2: castleData = _castleLargeData;  break;
                    default: castleData = _castleSmallData; break;
                }

                for (int k = 0; k < castleData.Count; k++)
                {
                    for (int i = 0; i < castleData[k].Count; i++)
                    {
                        var colorTint = CalculateTint(castleData[k][i].SpriteCoords);
                        Tile spriteTile = new Tile("Castle", castleData[k][i].IsWalkable, castleData[k][i].SpriteCoords, colorTint);
                        spriteTile.Position = new Vector2(castlePosition.X + i * Constants.DEFAULT_ENTITY_SIZE, castlePosition.Y + k * Constants.DEFAULT_ENTITY_SIZE);
                        world.AddTile(new Coords2D(spriteTile.Position), spriteTile);
                    }
                }
            }

            //Place Start Village...
            for (int k = 0; k < _startVillageData.Count; k++)
            {
                for (int i = 0; i < _startVillageData[k].Count; i++)
                {
                    Tile spriteTile = new Tile("StartVillage", _startVillageData[k][i].IsWalkable, _startVillageData[k][i].SpriteCoords);
                    spriteTile.Position = new Vector2((world.StartPos.X - (9 * Constants.DEFAULT_ENTITY_SIZE)) + (i * Constants.DEFAULT_ENTITY_SIZE), (world.StartPos.Y-(5 * Constants.DEFAULT_ENTITY_SIZE)) + (k * Constants.DEFAULT_ENTITY_SIZE));
                    world.AddTile(new Coords2D(spriteTile.Position), spriteTile);
                }
            }

            //Create roads...

            //Create lakes and rivers...?


            foreach (var tile in world.WorldTiles)
            {
                scene?.Add(tile.Value);
            }

            return true;
        }

        private static Color CalculateTint(Coords2D tilePos) 
        {
            var posB = new Vector2(world.StartPos.X, world.StartPos.Y);

            var dist = Vector2.Distance(posB, tilePos);
            var maxDist = Vector2.Distance(new Vector2(0, 0), posB);
            var inLerp = MathFunctions.InverseLerp(maxDist, 0, dist);
            var lerp = MathFunctions.Lerp(65, 255, inLerp);
            return new Color((int)lerp, (int)lerp, (int)lerp, 255);
        }
    }

    public enum POIType
    {
        CastleSmall,
        CastleMedium,
        CastleLarge,
        GraveyardMedium,
    }
}