using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollenBar : MonoBehaviour
{
	public GameObject Bar;
	public Color DefaultColor;
	public Color MaxedColor;

	void Start()
	{
		SetPercentage(0);
		Bar.GetComponent<SpriteRenderer>().color = DefaultColor;
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
