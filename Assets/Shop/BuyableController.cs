using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyableController : MonoBehaviour
{
	public Buyable item;
	public PlayerInventory inventory;

	public void Start()
	{
		Image image = GetComponentsInChildren<Image>()[1];
		Text text = GetComponentInChildren<Text>();

		image.sprite = item.sprite;
		text.text = item.displayname;
	}

	public void Buy()
	{
		if (inventory.pollen >= item.price)
		{
			inventory.pollen -= item.price;
			inventory.AddItem(item.id);
		}
	}
}
