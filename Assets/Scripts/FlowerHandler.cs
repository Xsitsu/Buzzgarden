using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerHandler : MonoBehaviour
{
	static private FlowerHandler _instance;
	static public FlowerHandler Instance { get { return _instance; } }
	public GameObject PollenBar;
	List<Flower> Flowers;

	void Awake()
	{
		_instance = this;
	}

	void OnDestroy()
	{
		_instance = null;
	}

	void Start()
	{
		Flowers = new List<Flower>();
	}

	void Update()
	{

	}

	public PollenBar CreatePollenBar()
	{
		GameObject bar = Instantiate(PollenBar);
		bar.transform.SetParent(transform);
		return bar.GetComponent<PollenBar>();
	}
}
