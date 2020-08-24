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
				if (display.flowerType != null)
				{
					float pollen = PlayerInventory.Instance.GetPollen(display.flowerType.Id);
					if (pollen > 0)
					{
						display.Show();
						display.DisplayPollen((int)pollen);
					}
					else
					{
						display.Hide();
					}
				}
				else
				{
					display.Hide();
				}
			}
		}
	}

	public void ShowShop()
	{
		ShopUI.Instance.Enable();
	}
	public void HideShop()
	{
		ShopUI.Instance.Disable();
	}
}
