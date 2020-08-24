using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower
{
	public FlowerType flowerType;
	public float CurrentPollen { get; private set; }
	public float TotalPollen { get; private set; }
	float _regenTimer;
	public ParticleSystem pollenParticles;
	MapTile tile;
	PollenBar pollenBar;

	public Flower()
	{
		CurrentPollen = 0;
		TotalPollen = 0;
		_regenTimer = 0;

		pollenBar = FlowerHandler.Instance.CreatePollenBar();
		pollenParticles = FlowerHandler.Instance.CreatePollenParticles();
	}
	public void Destroy()
	{
		if (pollenBar != null)
		{
			Object.Destroy(pollenBar.gameObject);
		}

		if (pollenParticles != null)
		{
			Object.Destroy(pollenParticles.gameObject);
		}

		if (tile != null)
		{
			tile.RemoveFlower();
		}
	}
	public void AddToTile(MapTile tile)
	{
		this.tile = tile;
		foreach (IFlowerEffect effect in flowerType.OnAddedEffects)
		{
			effect.Apply(tile);
		}
	}
	public void RemoveFromTile(MapTile tile)
	{
		this.tile = null;
		foreach (IFlowerEffect effect in flowerType.OnRemovedEffects)
		{
			effect.Apply(tile);
		}
	}
	public void SetTile(MapTile tile)
	{
		this.tile = tile;
	}

	public void Update(float step)
	{
		if (flowerType.LifetimePollen > TotalPollen)
		{
			if (_regenTimer > 0)
			{
				_regenTimer -= step;
			}
			else if (CurrentPollen < flowerType.MaxPollen)
			{
				float addPollen = flowerType.PollenGenerationRate * step;
				float diff = flowerType.MaxPollen - CurrentPollen;
				if (addPollen > diff)
				{
					addPollen = diff;
				}

				CurrentPollen += addPollen;
				TotalPollen += addPollen;

				if (CurrentPollen > flowerType.MaxPollen)
				{
					CurrentPollen = flowerType.MaxPollen;
				}
			}
		}
		else
		{
			pollenBar.SetMaxed();
		}

		pollenBar.SetPercentage(CurrentPollen / flowerType.MaxPollen);
	}

	public void SetPosition(int x, int y)
	{
		pollenBar.transform.position = new Vector3(x, y, 0);
		pollenParticles.transform.position = new Vector3(x + 0.5f, y + 0.5f, 0);
	}

	public float HarvestPollen(float toHarvest)
	{
		if (toHarvest >= CurrentPollen)
		{
			toHarvest = CurrentPollen;

			if (TotalPollen > flowerType.LifetimePollen)
			{
				this.Destroy();
			}
		}

		CurrentPollen -= toHarvest;
		//emitCounter += toHarvest;

		if (CurrentPollen > 0)
		{
			var particleMain = pollenParticles.main;
			particleMain.startColor = flowerType.FlowerColor;

			//emitCounter = 0;
			pollenParticles.Emit(1);
		}

		_regenTimer = flowerType.RegenTimer;

		return toHarvest;
	}
}
