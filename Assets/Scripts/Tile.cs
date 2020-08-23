using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile
{
	public enum TileType { None, Grass, Dirt }

	public MapTile.TileType Type;
	public Flower Flower;
	public bool Updated = false;

	public MapTile()
	{
		Type = MapTile.TileType.None;
		Flower = null;
	}

	public MapTile(MapTile.TileType type)
	{
		this.Type = type;
	}

	public MapTile(MapTile.TileType type, Flower flower)
	{
		this.Type = type;
		this.Flower = flower;
	}

	public void Update(float step)
	{
		if (Flower != null)
		{
			Flower.Update(step);
		}
	}

	public void RemoveFlower()
	{
		Flower = null;
		Updated = true;
	}
}
