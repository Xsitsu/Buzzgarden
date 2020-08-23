using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower
{
	public float CurrentPollen { get; private set; }
	public float MaxPollen { get; private set; }
	public float PollenRate { get; private set; }
	public float TotalPollen { get; private set; }
	public float MaxTotalPollen { get; private set; }
	public float RegenTimer { get; private set; }
	float _regenTimer;
	public Color PetalsColor { get; set; }
	public ParticleSystem pollenParticles;
	//private float emitCounter;

	MapTile tile;
	PollenBar pollenBar;

	public Flower(MapTile tile)
	{
		this.tile = tile;

		PetalsColor = new Color(1f, 1f, 1f, 1f);
		CurrentPollen = 0;
		MaxPollen = 40;
		PollenRate = 1;

		TotalPollen = 0;
		MaxTotalPollen = 80;

		RegenTimer = 2;
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
			tile = null;
		}
	}

	public void Update(float step)
	{
		if (MaxTotalPollen > TotalPollen)
		{
			if (_regenTimer > 0)
			{
				_regenTimer -= step;
			}
			else
			{
				float addPollen = PollenRate * step;
				CurrentPollen += addPollen;
				TotalPollen += addPollen;

				if (CurrentPollen > MaxPollen)
				{
					CurrentPollen = MaxPollen;
				}
			}
		}
		else
		{
			pollenBar.SetMaxed();
		}

		pollenBar.SetPercentage(CurrentPollen / MaxPollen);
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

			if (TotalPollen > MaxTotalPollen)
			{
				this.Destroy();
			}
		}

		CurrentPollen -= toHarvest;
		//emitCounter += toHarvest;

		if (CurrentPollen > 0)
		{
			//emitCounter = 0;
			pollenParticles.Emit(1);
		}

		_regenTimer = RegenTimer;

		return toHarvest;
	}
}
