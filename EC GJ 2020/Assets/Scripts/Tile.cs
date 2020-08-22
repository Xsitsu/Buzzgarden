using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public enum TileType { None, Grass, Dirt }

    public TileType type;
    public Flower flower;
    public Tile()
    {
        type = TileType.None;
        flower = null;
    }

    public Tile(TileType type)
    {
        this.type = type;
    }
    public Tile(TileType type, Flower flower)
    {
        this.type = type;
        this.flower = flower;
    }
}
