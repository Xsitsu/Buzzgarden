using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FlowerType", menuName = "FlowerGame/FlowerType")]
public class FlowerType : ScriptableObject
{
	public Color FlowerColor;
	public int MaxPollen;
	public int LifetimePollen;
	public float PollenGenerationRate;
	public float RegenTimer;
	public FlowerEffectBase[] OnAddedEffects;
	public FlowerEffectBase[] OnRemovedEffects;
	public int StorePrice;
	public string StoreName;
}
