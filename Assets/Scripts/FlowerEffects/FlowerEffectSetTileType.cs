using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SetTileType", menuName = "FlowerGame/FlowerEffect/SetTileType")]
public class FlowerEffectSetTileType : FlowerEffectBase
{
    public MapTile.TileType Type;
    public override void Apply(MapTile tile)
    {
        tile.Type = this.Type;
    }
}
