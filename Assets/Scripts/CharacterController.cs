using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
	private float movementSpeed = 3f;
	private Rigidbody rb;
	private Vector3 movement;
    private float interactionDistance = 3f;

	private Animator anim;

	private Vector3[] boothCoords = new Vector3[] {
		new Vector3(5.392f, 0.313f, -10.281f),
		new Vector3(15.01f, 0.325f, -10.29f),
		new Vector3(23.93f, 0.325f, -10.29f)
	};

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
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

			if (horizontalInput != 0) {
				Debug.Log("isRunning => true olarak değiştirildi");
				anim.SetBool("isRunning", true);
			} else {
				Debug.Log("isRunning => false olarak değiştirildi");
				anim.SetBool("isRunning", false);
			}

			movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;
		}
	}

	void FixedUpdate()
	{
		rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
	}
}
