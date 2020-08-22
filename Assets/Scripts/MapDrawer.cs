using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapDrawer : MonoBehaviour
{
    public Tilemap TilemapDirt;
    public Tilemap TilemapGrass;
    public Tilemap TilemapFlowers;
    public Tile DirtTile;
    void Start()
    {

    }

    void Update()
    {

    }
    public void DrawMap(Map map)
    {
        //Debug.Log("Want to draw map of size:" + map.SizeX + "/" + map.SizeY);
        TilemapDirt.ClearAllTiles();

        Vector3Int pos = new Vector3Int();
        for (int x = 0; x < map.SizeX; x++)
        {
            pos.x = x;
            for (int y = 0; y < map.SizeY; y++)
            {
                pos.y = y;
                TilemapDirt.SetTile(pos, DirtTile);
                MapTile tile = map.Tiles[x,y];
                if (tile.Type == MapTile.TileType.Grass)
                {
                    TilemapDirt.SetTile(pos, null); //temp
                    //TilemapGrass.SetTile(pos, GrassTile);
                }
            }
        }

    }


}

