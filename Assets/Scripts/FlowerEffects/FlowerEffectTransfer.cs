using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FlowerEffectTransfer", menuName = "FlowerGame/FlowerEffect/Transfer")]
public class FlowerEffectTransfer : FlowerEffectBase
{
    [Range(1, 100)]
    public float TransferSpeed;
    public override void Apply(MapTile tile, float step)
    {
        int x = (int)tile.Coordinates.x;
        int y = (int)tile.Coordinates.y;
        MapTile left = MapHandler.Instance.Map.GetTile(x - 1, y);
        MapTile right = MapHandler.Instance.Map.GetTile(x + 1, y);
        
        if (left != null && left.Flower != null && right != null && right.Flower != null)
        {
            if (!right.Flower.IsFull())// && !right.Flower.IsRegenning())
            {
                if (left.Flower.CurrentPollen > 0)
                {
                    left.Flower.SetParticlesTarget(tile.Flower.flowerTransform);
                    float harvested = left.Flower.TakePollen(TransferSpeed * step);
                    if (harvested > 0)
                    {
                        tile.Flower.AddPollen(harvested);
                        tile.Flower.SetParticlesTarget(right.Flower.flowerTransform);
                        tile.Flower.TakePollen(harvested);
                        right.Flower.AddPollen(harvested);
                    }
                }
            }
        }
    }
}
