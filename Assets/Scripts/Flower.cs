using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower
{
    public enum FlowerType { None, Yellow, Red, Green, Blue}
    public FlowerType Type;
    public float Pollen { get; private set; }
    public float MaxPollen { get; private set; }
    public float PollenRate { get; private set; }
    public float TotalPollen { get; private set; }
    public float MaxTotalPollen { get; private set; }
    
    MapTile tile;
    PollenBar pollenBar;
    public Flower(MapTile tile)
    {
        this.tile = tile;

        Type = FlowerType.None;
        Pollen = 0;
        MaxPollen = 40;
        PollenRate = 1;

        TotalPollen = 0;
        MaxTotalPollen = 80;

        pollenBar = FlowerHandler.Instance.CreatePollenBar();
    }
    public void Destroy()
    {
        if (pollenBar != null)
        {
            Object.Destroy(pollenBar.gameObject);
        }
        if (tile != null)
        {
            tile.RemoveFlower();
            tile = null;
        }
    }
    public void Update(float step)
    {
        if (MaxTotalPollen > TotalPollen)
        {
            float addPollen = PollenRate * step;
            Pollen += addPollen;
            TotalPollen += addPollen;
            if (Pollen > MaxPollen)
            {
                Pollen = MaxPollen;
            }
        }
        else
        {
            pollenBar.SetMaxed();
        }
        
        pollenBar.SetPercentage(Pollen / MaxPollen);
    }
    public void SetPosition(int x, int y)
    {
        pollenBar.transform.position = new Vector3(x, y, 0);
    }
    public float HarvestPollen(float amount)
    {
        float harvested = amount;
        if (Pollen < amount)
        {
            harvested = Pollen;
            Pollen = 0;

            if (TotalPollen > MaxTotalPollen)
            {
                this.Destroy();
            }
        }
        else
        {
            Pollen -= amount;
        }
        return harvested;
    }
}
