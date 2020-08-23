using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile
{
	public enum TileType { None, Grass, Dirt }

	public Vector2 Coordinates { get; private set; }
	public MapTile.TileType Type;
	public Flower Flower { get; private set; }
	public bool Updated = false;

	public MapTile(Vector2 coords)
	{
		Coordinates = coords;
		Type = MapTile.TileType.None;
		Flower = null;
	}
	public void Update(float step)
	{
		if (Flower != null)
		{
			Flower.Update(step);
		}
	}
	public void AddFlower(Flower flower)
	{
		Flower = flower;
		Flower.AddToTile(this);
		Updated = true;
	}
	public void RemoveFlower()
	{
		if (Flower != null)
		{
			Flower old = Flower;
			Flower = null;
			old.RemoveFromTile(this);
			Updated = true;
		}
	}
}
