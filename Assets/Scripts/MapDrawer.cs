using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDrawer : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }
    public void DrawMap(Map map)
    {
        Debug.Log("Want to draw map of size:" + map.SizeX + "/" + map.SizeY);
    }


}

