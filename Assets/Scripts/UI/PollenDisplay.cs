using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PollenDisplay : MonoBehaviour
{
    public FlowerType flowerType;
	public TMPro.TextMeshProUGUI PollenText;
    public GameObject PetalsImage;
	void Start()
	{
        if (flowerType != null)
        {
            PetalsImage.GetComponent<Image>().color = flowerType.FlowerColor;
        }
        else
        {
            Hide();
        }
	}

	void Update()
	{

	}

    public void DisplayPollen(int pollen)
    {
        if (pollen >= 1000000)
        {
            float num = ((float)(pollen / 100000)) / 10;
            PollenText.text = num.ToString() + "M";
        }
        else if (pollen >= 10000)
        {
            float num = ((float)(pollen / 1000));
            PollenText.text = num.ToString() + "K";
        }
        else if (pollen >= 1000)
        {
            float num = ((float)(pollen / 100)) / 10;
            PollenText.text = num.ToString() + "K";
        }
        else
        {
            PollenText.text = pollen.ToString();
        }
    }
    public int GetPollenAmount()
    {
        if (flowerType != null)
        {
            return (int)PlayerInventory.Instance.GetPollen(flowerType.Id);
        }
        return 0;
    }

	public void Show()
	{
		gameObject.SetActive(true);
	}
	public void Hide()
	{
		gameObject.SetActive(false);
	}
}
