using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuyableController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public ShopItem item;
	public GameObject NameLabel;
	public GameObject PetalsImage;
	public TMPro.TextMeshProUGUI DescriptionText;
	public GameObject PollenDisplayList;

	void Start()
	{
		if (item != null)
		{
			NameLabel.GetComponent<Text>().text = item.Flower.Name;
			PetalsImage.GetComponent<Image>().color = item.Flower.FlowerColor;
			if (PollenDisplayList != null)
			{
				ClearPollenCosts();
			}
		}
		else
		{
			gameObject.SetActive(false);
		}
	}
	public bool CanBuy()
	{
		foreach (ShopItemCost cost in item.Costs)
		{
			if (PlayerInventory.Instance.GetPollen(cost.Flower.Id) < cost.Pollen)
			{
				return false;
			}
		}
		return true;
	}
	public void Buy()
	{
		if (CanBuy())
		{
			foreach (ShopItemCost cost in item.Costs)
			{
				PlayerInventory.Instance.SubtractPollen(cost.Flower.Id, cost.Pollen);
				FlowerPlacer.Instance.SetFlowerType(item.Flower);
			}
		}
	}

	void DisplayPollenCosts(ShopItemCost[] costs)
	{
		foreach (Transform child in PollenDisplayList.transform)
		{
			PollenDisplay display = child.GetComponent<PollenDisplay>();
			if (display)
			{
				if (display.flowerType != null)
				{
					display.Hide();
					foreach (ShopItemCost cost in costs)
					{
						if (display.flowerType == cost.Flower)
						{
							display.Show();
							display.DisplayPollen(cost.Pollen);
						}
					}
				}
				else
				{
					display.Hide();
				}
			}
		}
	}
	void ClearPollenCosts()
	{
		foreach (Transform child in PollenDisplayList.transform)
		{
			PollenDisplay display = child.GetComponent<PollenDisplay>();
			if (display)
			{
				display.Hide();
			}
		}
	}
	public void OnPointerEnter(PointerEventData data)
	{
		if (DescriptionText != null)
		{
			DescriptionText.text = item.Flower.Description;
		}
		if (PollenDisplayList != null)
		{
			DisplayPollenCosts(item.Costs);
		}
	}

	public void OnPointerExit(PointerEventData data)
	{
		if (DescriptionText != null)
		{
			DescriptionText.text = "";
		}
		if (PollenDisplayList != null)
		{
			ClearPollenCosts();
		}
	}

	public void Hide()
	{
		gameObject.SetActive(false);
	}
	public void Show()
	{
		gameObject.SetActive(true);
	}
}
