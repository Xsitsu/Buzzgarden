using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower
{
    public enum FlowerType { None, Yellow, Red, Green, Blue}
    public FlowerType Type;
    public Flower()
    {
        Type = FlowerType.None;
    }
    public Flower(Flower.FlowerType type)
    {
        Type = type;
    }
}
