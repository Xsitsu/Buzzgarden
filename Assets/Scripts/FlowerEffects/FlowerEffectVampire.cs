using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FlowerEffectVampire", menuName = "FlowerGame/FlowerEffect/Vampire")]
public class FlowerEffectVampire : FlowerEffectBase
{
    [Range(0, 100)]
    public float DrainSpeed;
    [Range(0, 100)]
    public int Range;
    public override void Apply(MapTile tile, float step)
    {
        if (tile.Flower != null)
        {
            Debug.Log("Vampire Total range: " + (Range + tile.Flower.RangeBonus));
            List<MapTile> tiles = MapHandler.Instance.Map.GetInRange(tile, Range + tile.Flower.RangeBonus);
            foreach (MapTile t in tiles)
            {
                if (!tile.Flower.IsFull())
                {
                    if (t != tile)
                    {
                        if (t.Flower != null && t.Flower.flowerType.PollenGenerationRate > 0)
                        {
                            if (t.Flower.CurrentPollen > 0)
                            {
                                t.Flower.SetParticlesTarget(tile.Flower.flowerTransform);
                                float harvested = t.Flower.TakePollen(DrainSpeed * step);
                                if (harvested > 0)
                                {
                                    tile.Flower.AddPollen(harvested);
                                }
                            }
                        }
                    }
                }
            }
        }
        
    }
}
