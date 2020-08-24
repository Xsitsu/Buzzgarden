using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SetAdjacentTileType", menuName = "FlowerGame/FlowerEffect/SetAdjacentTileType")]
public class FlowerEffectSetAdjacentTileType : FlowerEffectBase
{
    public MapTile.TileType Type;
    public override void Apply(MapTile tile)
    {
        List<MapTile> tiles = MapHandler.Instance.Map.GetAdjacent(tile);
        foreach (MapTile t in tiles)
        {
            t.Type = this.Type;
        }
    }
}
