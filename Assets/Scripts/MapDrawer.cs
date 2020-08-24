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
	public Tilemap TilemapFlowerPetals;
	public TileSet TileSet;

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
		TilemapFlowerPetals.ClearAllTiles();

		Vector3Int pos = new Vector3Int();
		for (int x = 0; x < map.SizeX; x++)
		{
			pos.x = x;
			for (int y = 0; y < map.SizeY; y++)
			{
				pos.y = y;

				MapTile tile = map.Tiles[x, y];
				if (tile.Type == MapTile.TileType.Grass)
				{
					TilemapGrass.SetTile(pos, TileSet.GrassTile);
				}
				else if (tile.Type == MapTile.TileType.Dirt)
				{
					TilemapDirt.SetTile(pos, TileSet.DirtTile);
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
				else if (tile.Type == MapTile.TileType.None)
				{
					bool up = (GetTileType(map, x, y + 1) != MapTile.TileType.None);
					bool down = (GetTileType(map, x, y - 1) != MapTile.TileType.None);
					bool left = (GetTileType(map, x - 1, y) != MapTile.TileType.None);
					bool right = (GetTileType(map, x + 1, y) != MapTile.TileType.None);

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

					TilemapFlowerPetals.SetTile(pos, TileSet.FlowerPetalsTile);
					TilemapFlowerPetals.SetTileFlags(pos, TileFlags.None);
					TilemapFlowerPetals.SetColor(pos, tile.Flower.flowerType.FlowerColor);
				}

				if (x == 0)
				{
					if (tile.Type != MapTile.TileType.None)
					{
						int index = GrassBordersToIndex(false, false, false, true);
						TilemapGrass.SetTile(new Vector3Int(pos.x - 1, pos.y, pos.z), TileSet.BorderTiles[index]);
					}
				}
				if (x == map.SizeX - 1)
				{
					if (tile.Type != MapTile.TileType.None)
					{
						int index = GrassBordersToIndex(false, false, true, false);
						TilemapGrass.SetTile(new Vector3Int(pos.x + 1, pos.y, pos.z), TileSet.BorderTiles[index]);
					}
				}
				if (y == 0)
				{
					if (tile.Type != MapTile.TileType.None)
					{
						int index = GrassBordersToIndex(true, false, false, false);
						TilemapGrass.SetTile(new Vector3Int(pos.x, pos.y - 1, pos.z), TileSet.BorderTiles[index]);
					}
				}
				if (y == map.SizeY - 1)
				{
					if (tile.Type != MapTile.TileType.None)
					{
						int index = GrassBordersToIndex(false, true, false, false);
						TilemapGrass.SetTile(new Vector3Int(pos.x, pos.y + 1, pos.z), TileSet.BorderTiles[index]);
					}
				}
			}
		}
	}
}
