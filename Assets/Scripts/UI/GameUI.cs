using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
	public TMPro.TextMeshProUGUI PollenText;

	void Start()
	{

	}

	void Update()
	{
		int pollen = PlayerInventory.Instance.Pollen;
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
}
