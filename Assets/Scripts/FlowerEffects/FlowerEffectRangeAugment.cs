using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FlowerEffectRangeAugment", menuName = "FlowerGame/FlowerEffect/RangeAugment")]
public class FlowerEffectRangeAugment : FlowerEffectBase
{
    List<Flower> parsedFlowers = new List<Flower>();
    [Range(-100, 100)]
    public int RangeAugment;
    [Range(1, 100)]
    public int Range;
    public override void Apply(MapTile tile, float step)
    {
        List<Flower> rangeFlowers = new List<Flower>();
        List<MapTile> tiles = MapHandler.Instance.Map.GetInRange(tile, Range + tile.Flower.RangeBonus);
        foreach (MapTile t in tiles)
        {
            if (t != tile)
            {
                if (t.Flower != null)
                {
                    rangeFlowers.Add(t.Flower);
                    if (!parsedFlowers.Contains(t.Flower))
                    {
                        t.Flower.RangeBonus += RangeAugment;
                    }
                }
            }
        }

        foreach (Flower f in parsedFlowers)
        {
            if (!(rangeFlowers.Contains(f)))
            {
                if (f.HasTile())
                {
                    f.RangeBonus -= RangeAugment;
                }
            }
        }

        parsedFlowers = rangeFlowers;
    }
}
