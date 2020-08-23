using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuyableController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public Buyable item;
	public PlayerInventory inventory;

	public TMPro.TextMeshProUGUI itemTextTarget;
	public TMPro.TextMeshProUGUI itemPriceTarget;

	void Start()
	{
		var images = GetComponentsInChildren<Image>();
		var text = GetComponentInChildren<Text>();

		images[1].sprite = item.sprite;
		images[1].color = item.spriteColor;
		images[2].sprite = item.spriteDetail;
		text.text = item.displayname;

		if (itemTextTarget && itemPriceTarget)
		{
			itemTextTarget.text = "Item: None";
			itemPriceTarget.text = "Price: 0 pollen";
		}
	}

	public void Buy()
	{
		if (inventory.Pollen >= item.price)
		{
			inventory.SubtractPollen(item.price);
			inventory.AddItem(item.id);
		}
	}

	public void OnPointerEnter(PointerEventData data)
	{
		if (itemTextTarget && itemPriceTarget)
		{
			itemTextTarget.text = "Item: " + item.hovertext;
			itemPriceTarget.text = "Price: " + item.price.ToString() + " pollen";
		}
	}

	public void OnPointerExit(PointerEventData data)
	{
		if (itemTextTarget && itemPriceTarget)
		{
			itemTextTarget.text = "Item: None";
			itemPriceTarget.text = "Price: 0 pollen";
		}
	}
}
