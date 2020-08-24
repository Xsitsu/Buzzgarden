using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TransmuteTile", menuName = "FlowerGame/FlowerEffect/TransmuteTile")]
public class FlowerEffectTransmuteTile : FlowerEffectBase
{
    public MapTile.TileType FromType;
    public MapTile.TileType ToType;
    [Range(0, 100)]
    public int Range;
    public override void Apply(MapTile tile, float step)
    {
        List<MapTile> tiles = MapHandler.Instance.Map.GetInRange(tile, Range + tile.Flower.RangeBonus);
        foreach (MapTile t in tiles)
        {
            if (t.Type == FromType)
            {
                t.Type = ToType;
            }
        }
    }
}
