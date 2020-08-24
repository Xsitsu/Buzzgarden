using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
	static private GameUI _instance;
	static public GameUI Instance { get { return _instance; } }
	public GameObject ShopFrame;
	void Awake()
	{
		_instance = this;
	}
	void Start()
	{

	}

	void Update()
	{

	}

	public void ShowShop()
	{
		ShopFrame.SetActive(true);
	}
	public void HideShop()
	{
		ShopFrame.SetActive(false);
	}
}
