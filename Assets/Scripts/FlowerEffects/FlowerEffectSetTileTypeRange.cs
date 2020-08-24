using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SetTileTypeRange", menuName = "FlowerGame/FlowerEffect/SetTileTypeRange")]
public class FlowerEffectSetTileTypeRange : FlowerEffectBase
{
    public MapTile.TileType Type;
    [Range(0, 100)]
    public int Range;
    public override void Apply(MapTile tile, float step)
    {
        if (tile.Flower != null)
        {
            Debug.Log("Set Tile Total range: " + (Range + tile.Flower.RangeBonus));
            List<MapTile> tiles = MapHandler.Instance.Map.GetInRange(tile, Range + tile.Flower.RangeBonus);
            foreach (MapTile t in tiles)
            {
                t.Type = this.Type;
            }
        }
    }
}
