using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollenBar : MonoBehaviour
{
	static Color MaxedColor = new Color(222 / 255f, 106f / 255f, 106f / 255f, 1f);
	public GameObject Bar;

	void Start()
	{
		SetPercentage(0);
	}

	public void SetPercentage(float p)
	{
		Bar.transform.localScale = new Vector3(p, 1, 1);
	}

	public void SetMaxed()
	{
		Bar.GetComponent<SpriteRenderer>().color = MaxedColor;
	}
}
