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
        List<MapTile> tiles = MapHandler.Instance.Map.GetInRange(tile, Range);
        foreach (MapTile t in tiles)
        {
            if (!tile.Flower.IsFull())
            {
                if (t != tile)
                {
                    if (t.Flower != null && t.Flower.flowerType != tile.Flower.flowerType)
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
