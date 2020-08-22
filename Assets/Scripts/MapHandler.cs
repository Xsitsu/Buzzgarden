using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MapDrawer))]
public class MapHandler : MonoBehaviour
{
	public Vector2 MapSize;
	Map map;
	MapDrawer mapDrawer;
	Rect mapRect;

	void Start()
	{
		map = new Map((int)MapSize.x, (int)MapSize.y);
		mapDrawer = GetComponent<MapDrawer>();

		mapRect = new Rect(0, 0, MapSize.x, MapSize.y);

		mapDrawer.DrawMap(map);
	}

	void Update()
	{

	}

	public bool ContainsCell(Vector3Int cell)
	{
		Vector2 check = new Vector2(cell.x, cell.y);
		return mapRect.Contains(check);
	}
}

	}
}
