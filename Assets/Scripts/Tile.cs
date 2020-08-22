using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile
{
    public enum Type { None, Grass, Dirt }

    public MapTile.Type type;
    public Flower flower;
    public MapTile()
    {
        type = MapTile.Type.None;
        flower = null;
    }

    public MapTile(MapTile.Type type)
    {
        this.type = type;
    }
    public MapTile(MapTile.Type type, Flower flower)
    {
        this.type = type;
        this.flower = flower;
    }
}
