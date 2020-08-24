using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
	static private GameUI _instance;
	static public GameUI Instance { get { return _instance; } }
	public GameObject ShopFrame;
	public GameObject PollenDisplayList;
	void Awake()
	{
		_instance = this;
	}
	void Start()
	{

	}

	void Update()
	{
		foreach (Transform child in PollenDisplayList.transform)
		{
			PollenDisplay display = child.GetComponent<PollenDisplay>();
			if (display)
			{
				if (display.GetPollenAmount() > 0)
				{
					display.Show();
				}
			}
		}
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
