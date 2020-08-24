using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopItem", menuName = "FlowerGame/ShopItem")]
public class ShopItem : ScriptableObject
{
    public FlowerType Flower;
    public ShopItemCost[] Costs;
}
