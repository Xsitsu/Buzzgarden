using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MapDrawer))]
public class MapHandler : MonoBehaviour
{
    static private MapHandler _instance;
    static public MapHandler Instance { get { return _instance; } }
	public Vector2 MapSize;
    public Map Map { get { return map; } }
	Map map;
	MapDrawer mapDrawer;
	Rect mapRect;
    void Awake()
    {
        _instance = this;
    }
	void Start()
	{
		map = new Map((int)MapSize.x, (int)MapSize.y);
		mapDrawer = GetComponent<MapDrawer>();

		mapRect = new Rect(0, 0, MapSize.x, MapSize.y);

		mapDrawer.DrawMap(map);
	}

	void Update()
	{
        map.Update(Time.deltaTime);
        if (map.NeedsRedraw)
        {
            map.NeedsRedraw = false;
            mapDrawer.DrawMap(map);
        }
	}

	public bool ContainsCell(Vector3Int cell)
	{
		Vector2 check = new Vector2(cell.x, cell.y);
		return mapRect.Contains(check);
	}
}
