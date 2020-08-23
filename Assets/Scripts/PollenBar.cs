using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollenBar : MonoBehaviour
{
    public GameObject Bar;
    void Start()
    {
        SetPercentage(0);
    }
    public void SetPercentage(float p)
    {
        Bar.transform.localScale = new Vector3(p, 1, 1);
    }
}
