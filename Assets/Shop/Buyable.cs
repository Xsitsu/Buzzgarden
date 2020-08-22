using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Buyable", menuName = "FlowerGame/Buyable")]
public class Buyable : ScriptableObject
{
	public string id;
	public string displayname;
	public string hovertext;
	public uint price;
	public Sprite sprite;
}
