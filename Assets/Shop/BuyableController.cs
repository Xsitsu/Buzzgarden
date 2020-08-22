using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuyableController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public Buyable item;
	public PlayerInventory inventory;

	public TMPro.TextMeshProUGUI itemText;
	public TMPro.TextMeshProUGUI itemPrice;
	public TMPro.TextMeshProUGUI currentPollen;

	public void Start()
	{
		Image image = GetComponentsInChildren<Image>()[1];
		Text text = GetComponentInChildren<Text>();

		image.sprite = item.sprite;
		text.text = item.displayname;

		itemText.text = "Item: None";
		itemPrice.text = "Price: 0 pollen";
		currentPollen.text = "You have: " + inventory.pollen.ToString() + " pollen";
	}

	public void Buy()
	{
		if (inventory.pollen >= item.price)
		{
			inventory.pollen -= item.price;
			inventory.AddItem(item.id);
			currentPollen.text = "You have: " + inventory.pollen.ToString() + " pollen";
		}
	}

	public void OnPointerEnter(PointerEventData data)
	{
		itemText.text = "Item: " + item.hovertext;
		itemPrice.text = "Price: " + item.price.ToString() + " pollen";
	}

	public void OnPointerExit(PointerEventData data)
	{
		itemText.text = "Item: None";
		itemPrice.text = "Price: 0 pollen";
	}
}
