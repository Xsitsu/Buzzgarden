using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class TileSelector : MonoBehaviour
{
    public MapHandler mapHandler;
    public Grid grid;
    public Tilemap tilemap;
    public Tile selectionTile;

    Vector3Int prevCell;
	Camera cam;
    Plane groundPlane;

	public void Start()
	{
		cam = Camera.main;
        groundPlane = new Plane(Vector3.up, Vector3.zero);
        prevCell = new Vector3Int(0, -1, 0);
	}

	public void Update()
	{
        Vector3 worldCoord = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cell = grid.WorldToCell(worldCoord);
        //cell.x = (int)Mathf.Clamp(cell.x, 0, mapHandler.MapSize.x);
        //cell.y = (int)Mathf.Clamp(cell.y, 0, mapHandler.MapSize.y);

        if (prevCell != cell)
        {
            tilemap.SetTile(prevCell, null);
            prevCell = cell;

            if (mapHandler.ContainsCell(cell))
            {
                tilemap.SetTile(cell, selectionTile);
            }
        }
        //Vector3 localCoord = grid.WorldToLocal(worldCoord);
        //Debug.Log("cell is " + cell + " and local coordinates are " + localCoord);
	}
}
