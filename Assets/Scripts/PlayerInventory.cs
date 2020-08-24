using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
	private static PlayerInventory _instance;
	public static PlayerInventory Instance { get { return _instance; } }
	private Dictionary<string, float> pollen;
	void Awake()
	{
		_instance = this;
	}
	void Start()
	{
		pollen = new Dictionary<string, float>();
	}
	void OnDestroy()
	{
		_instance = null;
	}
	public void AddPollen(string id, float amount)
	{
		float count;
		pollen.TryGetValue(id, out count);
		pollen[id] = count + amount;
	}
	public void SubtractPollen(string id, float amount)
	{
		float count;
		pollen.TryGetValue(id, out count);
		float set = count - amount;
		if (set < 0)
		{
			set = 0;
		}
		pollen[id] = set;
	}
	public float GetPollen(string id)
	{
		float count;
		pollen.TryGetValue(id, out count);
		return count;
	}
}
