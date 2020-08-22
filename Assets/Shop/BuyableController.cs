using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyableController : MonoBehaviour
{
	public Buyable item;
	public Inventory inventory;

	public void Buy()
	{
		if (inventory.pollen >= item.price)
		{
			inventory.pollen -= item.price;
			inventory.AddItem(item.id);
		}
	}
}
