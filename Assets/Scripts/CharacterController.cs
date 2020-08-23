using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterController : MonoBehaviour
{
	[Range(1, 20)]
	public float Speed = 1f; // tiles per second

	public Grid grid;
	public float PollenHarvestSpeed = 6f; // pollen per second
	public float PollenHarvestDistance = 1f; // tiles

	Camera cam;

	void Start()
	{
		cam = Camera.main;
	}

	void Update()
	{
		Vector3 vel = new Vector3();
		if (Input.GetKeyDown("a"))
		{
			gameObject.GetComponent<SpriteRenderer>().flipX = false;
		}
		else if (Input.GetKeyDown("d"))
		{
			gameObject.GetComponent<SpriteRenderer>().flipX = true;
		}

		if (Input.GetKey("w"))
		{
			vel.y += 1;
		}
		if (Input.GetKey("s"))
		{
			vel.y -= 1;
		}
		if (Input.GetKey("a"))
		{
			vel.x -= 1;
		}
		if (Input.GetKey("d"))
		{
			vel.x += 1;
		}

		Transform transform = GetComponent<Transform>();
		vel = vel.normalized * Speed;
		transform.position += vel * Time.deltaTime;

		if (true || Input.GetMouseButton(0))
		{
			//Debug.Log("Pos: " + transform.localPosition.x + "/" + transform.localPosition.y);
			float posX = transform.localPosition.x;
			float posY = transform.localPosition.y;
			int floorX = (int)Mathf.Floor(posX);
			int floorY = (int)Mathf.Floor(posY);
			float decX = (posX - floorX);
			float decY = (posY - floorY);

			int coordX = floorX;
			int coordY = floorY;

			if (decX >= 0.5f)
			{
				coordX++;
			}
			if (decY >= 0.5f)
			{
				coordY++;
			}

			//int coordX = (int)(transform.position.x + 0.5f);
			//int coordY = (int)(transform.position.y + 0.5f);

			Vector3Int cell = new Vector3Int(coordX, coordY, 0);
			//Vector3Int cell = TileSelector.Instance.SelectedCell;

			Vector2 diff = new Vector2((float)cell.x - transform.position.x, (float)cell.y - transform.position.y);
			float dist = diff.magnitude;

			MapTile tile = MapHandler.Instance.Map.GetTileFromCell(cell);
			if (dist <= PollenHarvestDistance)
			{
				if (tile != null && tile.Flower != null)
				{
					tile.Flower.pollenParticles.Play();
					float harvested = tile.Flower.HarvestPollen(PollenHarvestSpeed * Time.deltaTime);
					PlayerInventory.Instance.AddPollen(harvested);
				}
			}
			else
			{
				if (tile != null && tile.Flower != null)
				{
					tile.Flower.pollenParticles.Stop();
				}
			}
		}
	}
}
