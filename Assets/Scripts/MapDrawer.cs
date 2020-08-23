using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

using System;
using System.Linq;
using System.Text;
using System.IO;

public class MapDrawer : MonoBehaviour
{
    public Tilemap TilemapDirt;
    public Tilemap TilemapGrass;
    public Tilemap TilemapGrassCorner;
    public Tilemap TilemapFlowers;
    public TileSet TileSet;
    void Start()
    {
        
    }

    void Update()
    {

    }
    private MapTile.TileType GetTileType(Map map, int x, int y)
    {
        if (x < 0 || y < 0 || x >= map.SizeX || y >= map.SizeY)
        {
            //Debug.Log("Invalid coords: " + x + "/" + y);
            return MapTile.TileType.None;
        }

        try
        {
            return map.Tiles[x, y].Type;
        }
        catch (IndexOutOfRangeException e)
        {
            Debug.Log(e);
            Debug.Log("Error for coords: " + x + "/" + y);
        }

        return MapTile.TileType.None;
    }
    private int GrassBordersToIndex(bool up, bool down, bool left, bool right)
    {
        int index = 0;
        if (right) { index += 1; }
        if (left) { index += 2; }
        if (down) { index += 4; }
        if (up) { index += 8; }
        return index;
    }
    public void DrawMap(Map map)
    {
        //Debug.Log("Want to draw map of size:" + map.SizeX + "/" + map.SizeY);
        TilemapDirt.ClearAllTiles();
        TilemapGrass.ClearAllTiles();
        TilemapGrassCorner.ClearAllTiles();
        TilemapFlowers.ClearAllTiles();

        Vector3Int pos = new Vector3Int();
        for (int x = 0; x < map.SizeX; x++)
        {
            pos.x = x;
            for (int y = 0; y < map.SizeY; y++)
            {
                pos.y = y;

                TilemapDirt.SetTile(pos, TileSet.DirtTile);

                MapTile tile = map.Tiles[x, y];
                if (tile.Type == MapTile.TileType.Grass)
                {
                    TilemapGrass.SetTile(pos, TileSet.GrassTile);
                }
                else if (tile.Type == MapTile.TileType.Dirt)
                {
                    bool up = (GetTileType(map, x, y + 1) != MapTile.TileType.Dirt);
                    bool down = (GetTileType(map, x, y - 1) != MapTile.TileType.Dirt);
                    bool left = (GetTileType(map, x - 1, y) != MapTile.TileType.Dirt);
                    bool right = (GetTileType(map, x + 1, y) != MapTile.TileType.Dirt);

                    int setIndex = GrassBordersToIndex(up, down, left, right);
                    if (setIndex > 0)
                    {
                        TilemapGrass.SetTile(pos, TileSet.BorderTiles[setIndex]);
                    }
                }

                if (tile.Flower != null)
                {
                    TilemapFlowers.SetTile(pos, TileSet.FlowerTile);
                    TilemapFlowers.SetTileFlags(pos, TileFlags.None);
                    if (tile.Flower.Type == Flower.FlowerType.Yellow)
                    {
                        TilemapFlowers.SetColor(pos, new Color(1f, 1f, 0f, 1f));
                    }
                    else if (tile.Flower.Type == Flower.FlowerType.Red)
                    {
                        TilemapFlowers.SetColor(pos, new Color(1f, 0f, 0f, 1f));
                    }
                    else if (tile.Flower.Type == Flower.FlowerType.Green)
                    {
                        TilemapFlowers.SetColor(pos, new Color(0f, 1f, 0f, 1f));
                    }
                    else if (tile.Flower.Type == Flower.FlowerType.Blue)
                    {
                        TilemapFlowers.SetColor(pos, new Color(0f, 0f, 1f, 1f));
                    }
                }
            }
        }

    }


}

