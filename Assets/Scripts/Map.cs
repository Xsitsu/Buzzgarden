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
		MapTile tile;

		// Generate grass
		for (int x = 0; x < size_x; x++)
		{
			for (int y = 0; y < size_y; y++)
			{
				tile = new MapTile(new Vector2(x, y));
				tile.Type = MapTile.TileType.Grass;
				Tiles[x, y] = tile;
			}
		}

		// Generate starting dirt
		for (int dirt = 0; dirt < (SizeX * SizeY) / 2;)
		{
			var x = rand.Next(0, SizeX);
			var y = rand.Next(0, SizeY);

			tile = Tiles[x, y];
			if (tile.Type == MapTile.TileType.Grass)
			{
				tile.Type = MapTile.TileType.Dirt;
				dirt += 1;
			}
		}
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

		tiles.RemoveAll(t => t == null);
		return tiles;
	}
	void DoGetInRange(MapTile tile, int range, List<MapTile> tiles)
	{
		if (range > 0)
		{
			List<MapTile> adjacent = GetAdjacent(tile);
			foreach (MapTile t in adjacent)
			{
				if (!tiles.Contains(t))
				{
					tiles.Add(t);
					DoGetInRange(t, range - 1, tiles);
				}
			}
		}
	}
	public List<MapTile> GetInRange(MapTile tile, int range)
	{
		List<MapTile> tiles = new List<MapTile>();
		tiles.Add(tile);
		if (range > 0)
		{
			DoGetInRange(tile, range, tiles);
		}
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
	public void SeedFlowers(int amount, FlowerType type = null)
	{
		System.Random rand = new System.Random();

		// Generate starting default flowers
		for (int flowers = 0; flowers < amount;)
		{
			var x = rand.Next(0, SizeX);
			var y = rand.Next(0, SizeY);

			var tile = GetTile(x, y);
			if (tile.Type == MapTile.TileType.Grass && tile.Flower == null)
			{
				var flower = FlowerHandler.Instance.CreateFlower(type);
				flower.SetTile(tile);
				flower.SetPosition(x, y);
				tile.AddFlower(flower);
				flower.GeneratePollen(flower.flowerType.MaxPollen / 2);
				flowers += 1;
			}
		}
	}
}
