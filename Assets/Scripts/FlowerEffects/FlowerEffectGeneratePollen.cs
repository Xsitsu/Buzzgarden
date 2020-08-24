using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FlowerEffectGeneratePollen", menuName = "FlowerGame/FlowerEffect/GeneratePollen")]
public class FlowerEffectGeneratePollen : FlowerEffectBase
{
    public bool GenerateForSelf;
    [Range(0, 100)]
    public float GenerateSpeed;
    [Range(0, 100)]
    public int Range;
    public override void Apply(MapTile tile, float step)
    {
        List<MapTile> tiles = MapHandler.Instance.Map.GetInRange(tile, Range + tile.Flower.RangeBonus);
        foreach (MapTile t in tiles)
        {
            if (GenerateForSelf || t != tile)
            {
                if (t.Flower != null)
                {
                    if (!(t.Flower.IsRegenning()))
                    {
                        t.Flower.GeneratePollen(GenerateSpeed * step);
                    }
                }
            }
        }
    }
}
