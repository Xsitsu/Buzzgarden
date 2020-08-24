using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DieOnTileType", menuName = "FlowerGame/FlowerEffect/DieOnTileType")]
public class FlowerEffectDieOnTileType : FlowerEffectBase
{
    public MapTile.TileType Type;
    public override void Apply(MapTile tile, float step)
    {
        if (tile.Type == Type)
        {
            if (tile.Flower != null)
            {
                tile.Flower.Die();
            }
        }
    }
}
