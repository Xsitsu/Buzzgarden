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
				tile = new MapTile(new Vector2(x, y));
				tile.Type = MapTile.TileType.Grass;
				Tiles[x, y] = tile;

				int val = rand.Next(1, 100);
				if (val <= 1)
				{
					flower = FlowerHandler.Instance.CreateFlower();
					flower.SetTile(tile);
					flower.SetPosition(x, y);
					tile.AddFlower(flower);
				}
				else if (val <= 44)
				{
					tile.Type = MapTile.TileType.Dirt;
				}
			}
		}

		tile = Tiles[SizeX / 2, SizeY / 2];
		flower = FlowerHandler.Instance.CreateFlower();
		flower.SetTile(tile);
		flower.SetPosition(SizeX / 2, SizeY / 2);
		tile.Type = MapTile.TileType.Grass;
		tile.AddFlower(flower);
	}

	// Not a MonoBehavior class, so Update must be public so that it can be called elsewhere.
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
	public MapTile GetTile(int x, int y)
	{
		if (x >= 0 && y >= 0 && x < SizeX && y < SizeY)
		{
			return Tiles[x, y];
		}
		return null;
	}
	public MapTile GetTileFromCell(Vector3Int cell)
	{
		return GetTile(cell.x, cell.y);
	}
	public List<MapTile> GetAdjacent(MapTile tile)
	{
		int x = (int)tile.Coordinates.x;
		int y = (int)tile.Coordinates.y;
		List<MapTile> tiles = new List<MapTile>();
		tiles.Add(GetTile(x - 1, y));
		tiles.Add(GetTile(x + 1, y));
		tiles.Add(GetTile(x, y - 1));
		tiles.Add(GetTile(x, y + 1));
		return tiles;
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
