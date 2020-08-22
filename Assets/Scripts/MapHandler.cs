using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MapDrawer))]
public class MapHandler : MonoBehaviour
{
    public Vector2 MapSize; 
    private Map map;
    private MapDrawer mapDrawer;
    void Start()
    {
        map = new Map((int)MapSize.x, (int)MapSize.y);
        mapDrawer = GetComponent<MapDrawer>();

         mapDrawer.DrawMap(map);
    }

    void Update()
    {
       
    }
}

