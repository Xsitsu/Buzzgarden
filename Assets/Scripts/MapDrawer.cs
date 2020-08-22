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
        if (x < 0 || y < 0 || x > map.SizeX || y > map.SizeY)
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
        if (up && down && left && right) return 0; // no sprite yet
        if (up && down && left && !right) return 12;
        if (up && down && !left && right) return 13;
        if (up && down && !left && !right) return 0; // no sprite yet
        
        if (up && !down && left && right) return 10;
        if (up && !down && left && !right) return 2;
        if (up && !down && !left && right) return 4;
        if (up && !down && !left && !right) return 3;
        
        if (!up && down && left && right) return 11;
        if (!up && down && left && !right) return 7;
        if (!up && down && !left && right) return 9;
        if (!up && down && !left && !right) return 8;
        
        if (!up && !down && left && right) return 0; // no sprite yet
        if (!up && !down && left && !right) return 5;
        if (!up && !down && !left && right) return 6;
        if (!up && !down && !left && !right) return 0;

        // should never get here
        return 0;
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

                TilemapDirt.SetTile(pos, TileSet.Tiles[0]);

                MapTile tile = map.Tiles[x, y];
                if (tile.Type == MapTile.TileType.Grass)
                {
                    TilemapGrass.SetTile(pos, TileSet.Tiles[1]);
                }
                else if (tile.Type == MapTile.TileType.Dirt)
                {
                    bool up = (GetTileType(map, x, y + 1) == MapTile.TileType.Grass);
                    bool down = (GetTileType(map, x, y - 1) == MapTile.TileType.Grass);
                    bool left = (GetTileType(map, x - 1, y) == MapTile.TileType.Grass);
                    bool right = (GetTileType(map, x + 1, y) == MapTile.TileType.Grass);

                    int setIndex = GrassBordersToIndex(up, down, left, right);
                    if (setIndex > 0)
                    {
                        TilemapGrass.SetTile(pos, TileSet.Tiles[setIndex]);
                    }
                }
            }
        }

    }


}

