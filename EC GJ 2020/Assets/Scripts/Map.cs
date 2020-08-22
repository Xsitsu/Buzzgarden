using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    Tile[,] tiles;

    public Map(int size_x, int size_y)
    {
        tiles = new Tile[size_x, size_y];
    }
    public Map() : this(0, 0) {}
    public Map(System.Numerics.Vector2 size) : this((int)size.X, (int)size.Y) {}
}
