﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    public int SizeX;
    public int SizeY;
    public MapTile[,] Tiles;

    public Map(int size_x, int size_y)
    {
        SizeX = size_x;
        SizeY = size_y;
        Tiles = new MapTile[size_x, size_y];
        
        System.Random rand = new System.Random();

        //temp
        for (int x = 0; x < size_x; x++)
        {
            for (int y = 0; y < size_y; y++)
            {
                Tiles[x,y] = new MapTile(MapTile.TileType.Grass);

                int val = rand.Next(1, 3);
                if (val == 1)
                {
                    Tiles[x,y].Type = MapTile.TileType.Dirt;
                }
            }
        }
    }
    public Map() : this(0, 0) {}
    public Map(System.Numerics.Vector2 size) : this((int)size.X, (int)size.Y) {}
}
