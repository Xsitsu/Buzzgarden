using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "TileSet", menuName = "FlowerGame/TileSet")]
public class TileSet : ScriptableObject
{
	public Tile DirtTile;
	public Tile GrassTile;
	public Tile FlowerTile;
	public Tile FlowerPetalsTile;
	public Tile[] BorderTiles;
}
