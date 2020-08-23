using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
	private static PlayerInventory _instance;
	public static PlayerInventory Instance { get { return _instance; } }

	float pollen = 0;
	public int Pollen { get { return (int)Mathf.Floor(pollen); } }

	private Dictionary<string, int> items;

	void Awake()
	{
		_instance = this;
	}

	void Start()
	{
		items = new Dictionary<string, int>();
	}

	void OnDestroy()
	{
		_instance = null;
	}

	public void AddItem(string id)
	{
		int itemCount;
		items.TryGetValue(id, out itemCount);
		items[id] = itemCount += 1;

		Debug.Log("Inventory now has " + itemCount + " of '" + id + "'.");
	}

	public void AddPollen(float amount)
	{
		pollen += amount;
	}

	public void SubtractPollen(float amount)
	{
		pollen -= amount;
	}
}
