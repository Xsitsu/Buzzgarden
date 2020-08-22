using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile
{
    public enum TileType { None, Grass, Dirt }

    public MapTile.TileType Type;
    public Flower Flower;
    public MapTile()
    {
        Type = MapTile.TileType.None;
        Flower = null;
    }

    public MapTile(MapTile.TileType type)
    {
        this.Type = type;
    }
    public MapTile(MapTile.TileType type, Flower flower)
    {
        this.Type = type;
        this.Flower = flower;
    }
}
