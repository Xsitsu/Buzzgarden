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
		transform.localPosition = new Vector3(MapHandler.Instance.MapSize.x / 2, MapHandler.Instance.MapSize.y / 2, 0);
	}

	void Update()
	{
		Vector3 vel = new Vector3();

		if (Input.GetKey("w") || Input.GetKey("up"))
		{
			vel.y += 1;
		}
		if (Input.GetKey("s") || Input.GetKey("down"))
		{
			vel.y -= 1;
		}
		if (Input.GetKey("a") || Input.GetKey("left"))
		{
			vel.x -= 1;
		}
		if (Input.GetKey("d") || Input.GetKey("right"))
		{
			vel.x += 1;
		}

		if (vel.x > 0)
		{
			gameObject.GetComponent<SpriteRenderer>().flipX = true;
		}
		else if (vel.x < 0)
		{
			gameObject.GetComponent<SpriteRenderer>().flipX = false;
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
					tile.Flower.SetParticlesTarget(gameObject);
					FlowerType flowerType = tile.Flower.flowerType;
					float harvested = tile.Flower.HarvestPollen(PollenHarvestSpeed * Time.deltaTime);
					PlayerInventory.Instance.AddPollen(flowerType.Id, harvested);
					//tile.Flower.flowerType.PollenCollected += harvested;
					if (harvested > 0)
					{
						SoundManager.Instance.PlayGetPollen();
					}
					else
					{
						SoundManager.Instance.StopSound();
					}
				}
			}
		}
	}
}
