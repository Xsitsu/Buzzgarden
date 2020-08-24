using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuyableController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public FlowerType Item;
	public TileSet TileSet;
	public PlayerInventory Inventory;

	public TMPro.TextMeshProUGUI ItemTextTarget;
	public TMPro.TextMeshProUGUI ItemPriceTarget;

	void Start()
	{
		var images = GetComponentsInChildren<Image>();
		var text = GetComponentInChildren<Text>();

		images[1].sprite = TileSet.FlowerPetalsTile.sprite;
		images[1].color = Item.FlowerColor;
		images[2].sprite = TileSet.FlowerTile.sprite;
		text.text = Item.StoreName;

		if (ItemTextTarget && ItemPriceTarget)
		{
			ItemTextTarget.text = "Item: None";
			ItemPriceTarget.text = "Price: 0 pollen";
		}

		Inventory = PlayerInventory.Instance;
	}

	public void Buy()
	{
		/*
		if (Inventory.Pollen >= Item.StorePrice)
		{
			Inventory.SubtractPollen(Item.StorePrice);
			FlowerPlacer.Instance.SetFlowerType(Item);
		}
		*/
	}

	public void OnPointerEnter(PointerEventData data)
	{
		if (ItemTextTarget && ItemPriceTarget)
		{
			ItemTextTarget.text = "Item: " + Item.StoreName;
			ItemPriceTarget.text = "Price: " + Item.StorePrice.ToString() + " pollen";
		}
	}

	public void OnPointerExit(PointerEventData data)
	{
		if (ItemTextTarget && ItemPriceTarget)
		{
			ItemTextTarget.text = "Item: None";
			ItemPriceTarget.text = "Price: 0 pollen";
		}
	}
}
