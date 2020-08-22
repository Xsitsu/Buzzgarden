using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "TileSet", menuName = "FlowerGame/TileSet")]
public class TileSet : ScriptableObject
{
	public Tile[] Tiles;
}
