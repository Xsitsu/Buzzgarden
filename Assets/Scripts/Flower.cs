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
	public GameObject flowerTransform { get; private set; }
	bool isDead = false;

	public Flower()
	{
		CurrentPollen = 0;
		TotalPollen = 0;
		_regenTimer = 0;

		pollenBar = FlowerHandler.Instance.CreatePollenBar();
		pollenParticles = FlowerHandler.Instance.CreatePollenParticles();
		flowerTransform = FlowerHandler.Instance.CreateFlowerTransform();
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

		if (flowerTransform != null)
		{
			Object.Destroy(flowerTransform);
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
			effect.Apply(tile, 0);
		}
	}
	public void RemoveFromTile(MapTile tile)
	{
		this.tile = null;
		foreach (IFlowerEffect effect in flowerType.OnRemovedEffects)
		{
			effect.Apply(tile, 0);
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
			else
			{
				float addPollen = flowerType.PollenGenerationRate * step;
				float addedPollen = GeneratePollen(addPollen);	
				TotalPollen += addedPollen;
			}
		}
		else
		{
			pollenBar.SetMaxed();
		}

		pollenBar.SetPercentage(CurrentPollen / flowerType.MaxPollen);

		foreach (IFlowerEffect effect in flowerType.OnUpdateEffects)
		{
			if (!isDead && tile != null)
			{
				effect.Apply(tile, step);
			}
		}
	}
	public bool IsFull()
	{
		return (CurrentPollen >= flowerType.MaxPollen);
	}

	public float GeneratePollen(float addPollen)
	{
		float addedPollen = 0;
		if (!IsFull())
		{
			float diff = flowerType.MaxPollen - CurrentPollen;
			if (addPollen > diff)
			{
				addPollen = diff;
			}

			CurrentPollen += addPollen;

			if (CurrentPollen > flowerType.MaxPollen)
			{
				CurrentPollen = flowerType.MaxPollen;
			}

			addedPollen = addPollen;
		}
		return addedPollen;
	}
	public void SetPosition(int x, int y)
	{
		pollenBar.transform.position = new Vector3(x, y, 0);
		pollenParticles.transform.position = new Vector3(x + 0.5f, y + 0.5f, 0);
		flowerTransform.transform.position = new Vector3(x + 0.5f, y + 0.5f, 0);
	}

	public float TakePollen(float toHarvest)
	{
		if (toHarvest >= CurrentPollen)
		{
			toHarvest = CurrentPollen;

			if (TotalPollen >= flowerType.LifetimePollen)
			{
				Die();
			}

			CurrentPollen = 0;
		}
		else
		{
			CurrentPollen -= toHarvest;
		}

		if (toHarvest > 0)
		{
			var particleMain = pollenParticles.main;
			particleMain.startColor = flowerType.FlowerColor;

			pollenParticles.Emit(1);
		}

		return toHarvest;
	}
	public float HarvestPollen(float toHarvest)
	{
		_regenTimer = flowerType.RegenTimer;
		return TakePollen(toHarvest);
	}

	public void SetParticlesTarget(GameObject target)
	{
		pollenParticles.GetComponent<ParticleController>().SetTarget(target);
	}

	public void Die()
	{
		isDead = true;
		this.Destroy();
	}
}
