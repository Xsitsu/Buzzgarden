using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FlowerEffectLog", menuName = "FlowerGame/FlowerEffect/Log")]
public class FlowerEffectLog : FlowerEffectBase
{
    public string Message;
    public override void Apply(MapTile tile)
    {
        Debug.Log(Message);
    }
}
