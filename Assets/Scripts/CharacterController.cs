using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterController : MonoBehaviour
{
	[Range(1, 20)]
	public float Speed = 1f; // tiles per second (or something idk)

	Camera cam;

	public void Start()
	{
		cam = Camera.main;
	}

	public void Update()
	{
		Vector3 vel = new Vector3();
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
		Transform camTransform = cam.GetComponent<Transform>();

		Vector3 pos = new Vector3(transform.position.x, transform.position.y, camTransform.position.z);
		camTransform.position = pos;

		vel = vel.normalized * Speed;
		transform.position += vel * Time.deltaTime;
	}
}
