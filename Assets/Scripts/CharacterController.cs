using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
	public float movementSpeed = 3f;
	private Rigidbody rb;
	private Vector3 movement;
    public float interactionDistance = 3f;

	// public string EffectTypes = [
	// 	EffectType.Nane,
	// 	EffectType.Bogurtlen,

	// ];

	public Vector3[] boothCoords = new Vector3[] {
		new Vector3(5.392f, 0.313f, -10.281f),
		new Vector3(15.01f, 0.325f, -10.29f),
		new Vector3(23.93f, 0.325f, -10.29f)
	};

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			if (Vector3.Distance(transform.position, boothCoords[0]) <= interactionDistance)
			{
				Debug.Log("Stand 1 yakınında E basıldı.");
			}
			else if (Vector3.Distance(transform.position, boothCoords[1]) <= interactionDistance)
			{
				Debug.Log("Stand 2 yakınında E basıldı.");
			}
			else if (Vector3.Distance(transform.position, boothCoords[2]) <= interactionDistance)
			{
				Debug.Log("Stand 3 yakınında E basıldı.");
			}
		} else {
			float horizontalInput = Input.GetAxis("Horizontal");
			float verticalInput = Input.GetAxis("Vertical");

			movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;
		}
	}

	void FixedUpdate()
	{
		rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
	}
}
