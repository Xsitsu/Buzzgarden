using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class TileSelector : MonoBehaviour
{
	static private TileSelector _instance;
	static public TileSelector Instance { get { return _instance; } }
	public MapHandler mapHandler;
	public Grid grid;
	public Tilemap tilemap;
	public Tile selectionTile;
	public Vector3Int SelectedCell { get; private set; }
	public bool Visible = true;
	Camera cam;
	Plane groundPlane;

	void Awake()
	{
		_instance = this;
	}

	void Start()
	{
		cam = Camera.main;
		groundPlane = new Plane(Vector3.up, Vector3.zero);
		SelectedCell = new Vector3Int(0, -1, 0);
	}

	void Update()
	{
		Vector3 worldCoord = cam.ScreenToWorldPoint(Input.mousePosition);
		Vector3Int cell = grid.WorldToCell(worldCoord);
		//cell.x = (int)Mathf.Clamp(cell.x, 0, mapHandler.MapSize.x);
		//cell.y = (int)Mathf.Clamp(cell.y, 0, mapHandler.MapSize.y);

		if (SelectedCell != cell)
		{
			tilemap.SetTile(SelectedCell, null);
			SelectedCell = cell;

			if (true || mapHandler.ContainsCell(cell))
			{
				if (Visible)
				{
					tilemap.SetTile(cell, selectionTile);
				}
			}
		}
		//Vector3 localCoord = grid.WorldToLocal(worldCoord);
		//Debug.Log("cell is " + cell + " and local coordinates are " + localCoord);
	}
}
