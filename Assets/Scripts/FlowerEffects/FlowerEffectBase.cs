using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FlowerEffectBase : ScriptableObject, IFlowerEffect
{
    public abstract void Apply(MapTile tile);
}
