using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FlowerEffectGenerationMultiplier", menuName = "FlowerGame/FlowerEffect/GenerationMultiplier")]
public class FlowerEffectGenerationMultiplier : FlowerEffectBase
{
    [Range(1, 10)]
    public float Multiplier;
    [Range(1, 100)]
    public int Range;
    public override void Apply(MapTile tile, float step)
    {
        List<MapTile> tiles = MapHandler.Instance.Map.GetInRange(tile, Range + tile.Flower.RangeBonus);
        foreach (MapTile t in tiles)
        {
            if (t != tile)
            {
                if (t.Flower != null)
                {
                    if (!(t.Flower.IsRegenning()))
                    {
                        float useMult = Multiplier - 1;
                        t.Flower.GeneratePollen(t.Flower.flowerType.PollenGenerationRate * useMult * step);
                    }
                }
            }
        }
    }
}
