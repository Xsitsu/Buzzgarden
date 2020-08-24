using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopItemCost", menuName = "FlowerGame/ShopItemCost")]
public class ShopItemCost : ScriptableObject
{
    public FlowerType Flower;
    public int Pollen;
}
