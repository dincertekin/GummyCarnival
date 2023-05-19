using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
	public float movementSpeed = 3f;
	public Rigidbody rb;
    public float interactionDistance = 3f;

	public Animator anim;
	public SpriteRenderer sr;

	public Vector3[] boothCoords = new Vector3[] {
		new Vector3(5.392f, 0.313f, -10.281f),
		new Vector3(15.01f, 0.325f, -10.29f),
		new Vector3(23.93f, 0.325f, -10.29f)
	};

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		anim = transform.Find("Sprite").GetComponent<Animator>();
		sr = transform.Find("Sprite").GetComponent<SpriteRenderer>();
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

			Vector3 moveDir = new Vector3(horizontalInput, 0f, verticalInput);
			rb.velocity = moveDir * movementSpeed;

			if (horizontalInput != 0) {
				anim.SetBool("isHorizontalRunning", true);
			} else {
				anim.SetBool("isHorizontalRunning", false);
			}

			if (horizontalInput != 0 && horizontalInput < 0) {
				sr.flipX = true;
			} else if (horizontalInput != 0 && horizontalInput > 0) {
				sr.flipX = false;
			}
		}
	}
}
