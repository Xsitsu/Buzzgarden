using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PollenDisplay : MonoBehaviour
{
    public FlowerType flowerType;
    public GameObject Container;
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
            gameObject.SetActive(false);
        }
	}

	void Update()
	{
        if (flowerType == null) return;

        int pollen = (int)PlayerInventory.Instance.GetPollen(flowerType.Id);
        if (pollen > 0)
        {
            Show();
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
        else
        {
            Hide();
        }
	}

	public void Show()
	{
		Container.gameObject.SetActive(true);
	}
	public void Hide()
	{
		Container.gameObject.SetActive(false);
	}
}
