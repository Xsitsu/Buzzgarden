using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerHandler : MonoBehaviour
{
	static private FlowerHandler _instance;
	static public FlowerHandler Instance { get { return _instance; } }
	public GameObject PollenBar;
	public GameObject PollenParticles;
	public GameObject PollenTarget;
	public FlowerType DefaultFlowerType;
	GameObject FlowerTransform;
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
	public ParticleSystem CreatePollenParticles()
	{
		GameObject emitter = Instantiate(PollenParticles);
		emitter.transform.SetParent(transform);

		emitter.GetComponent<ParticleController>().SetTarget(PollenTarget);

		return emitter.GetComponent<ParticleSystem>();
	}
	public GameObject CreateFlowerTransform()
	{
		FlowerTransform = new GameObject();
		FlowerTransform.name = "FlowerTransform";
		GameObject obj = Instantiate(FlowerTransform);
		obj.transform.SetParent(transform);
		return obj;
	}
	public Flower CreateFlower(FlowerType flowerType = null)
	{
		Flower flower = new Flower();
		if (flowerType != null)
		{
			flower.flowerType = flowerType;
		}
		else
		{
			flower.flowerType = DefaultFlowerType;
		}

		return flower;
	}
}
