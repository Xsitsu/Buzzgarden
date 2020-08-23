using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    public int SizeX;
    public int SizeY;
    public MapTile[,] Tiles;
    public bool NeedsRedraw = false;

    public Map(int size_x, int size_y)
    {
        SizeX = size_x;
        SizeY = size_y;
        Tiles = new MapTile[size_x, size_y];
        
        System.Random rand = new System.Random();
        Flower flower;
        MapTile tile;

        //temp
        for (int x = 0; x < size_x; x++)
        {
            for (int y = 0; y < size_y; y++)
            {
                tile = new MapTile(MapTile.TileType.Grass);
                Tiles[x,y] = tile;

                int val = rand.Next(1, 100);
                if (val <= 1)
                {
                    flower = new Flower(tile);
                    flower.Type = Flower.FlowerType.Yellow;
                    flower.SetPosition(x, y);
                    tile.Flower = flower;
                }
                else if (val <= 44)
                {
                    tile.Type = MapTile.TileType.Dirt;
                }
            }
        }

        tile = Tiles[SizeX/2,SizeY/2];
        flower = new Flower(tile);
        flower.Type = Flower.FlowerType.Green;
        flower.SetPosition(SizeX/2, SizeY/2);
        tile.Type = MapTile.TileType.Grass;
        tile.Flower = flower;
    }
    public Map() : this(0, 0) {}
    public Map(System.Numerics.Vector2 size) : this((int)size.X, (int)size.Y) {}
    public void Update(float step)
    {
        foreach (MapTile tile in Tiles)
        {
            tile.Update(step);
            if (tile.Updated)
            {
                tile.Updated = false;
                NeedsRedraw = true;
            }
        }
    }
    public MapTile GetTileFromCell(Vector3Int cell)
    {
        int x = cell.x;
        int y = cell.y;

        if (x >= 0 && y >= 0 && x < SizeX && y < SizeY)
        {
            return Tiles[x,y];
        }
        return null;
    }
    public List<Flower> GetFlowers()
    {
        List<Flower> flowers = new List<Flower>();
        foreach (MapTile tile in Tiles)
        {
            if (tile.Flower != null)
            {
                flowers.Add(tile.Flower);
            }
        }
        return flowers;
    }
}
