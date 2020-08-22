using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterCamera : MonoBehaviour
{
	[Range(1, 20)]
	public float Speed = 2f; // tiles per second (or something idk)
    [Range(0.1f, 20)]
    public float Acceleration = 2f;
    [Range(0.1f, 20)]
    public float Deceleration = 1f;
    [Range(0, 1)]
    public float SnappingDistance = 0.01f;
	Camera cam;
    float curSpeed = 0f;
	void Start()
	{
		cam = Camera.main;
        Snap();
	}

	void Update()
	{
		Transform transform = GetComponent<Transform>();
		Transform camTransform = cam.GetComponent<Transform>();

        Vector2 charPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 camPos = new Vector2(camTransform.position.x, camTransform.position.y);

        Vector2 diff = charPos - camPos;
        float dist = diff.magnitude;
        if (true && dist < SnappingDistance)
        {
            Snap();
        }
        else
        {
            if (dist > (curSpeed / Deceleration))
            {
                curSpeed += Acceleration * Time.deltaTime;
            }
            else
            {
                curSpeed -= Deceleration * Time.deltaTime;
            }

            curSpeed = Mathf.Clamp(curSpeed, 0, Speed);

            camPos += diff.normalized * curSpeed * Time.deltaTime;
            camTransform.position = new Vector3(camPos.x, camPos.y, camTransform.position.z);
        }
	}

    public void Snap()
    {
        curSpeed = 0;
        Transform transform = GetComponent<Transform>();
		Transform camTransform = cam.GetComponent<Transform>();
        camTransform.position = new Vector3(transform.position.x, transform.position.y, camTransform.position.z);
    }
}
