using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	private Inventory _instance;
	public Inventory Instance { get { return _instance; } }

	public uint pollen = 0;

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
}
