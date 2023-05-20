using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
	public float movementSpeed = 4f;
	public Rigidbody rb;
    public float interactionDistance = 3f;

	public Animator anim;
	public SpriteRenderer sr;
	private Vector3 movement;

	private Vector3[] boothCoords = new [] {
		new Vector3(5.95f, 1.58f, -10.5f),
		new Vector3(14.95f, 1.58f, -10.5f),
		new Vector3(23.97f, 1.58f, -10.5f),
		new Vector3(33.16f, 1.58f, -10.5f),
		new Vector3(41.55f, 1.58f, -10.5f)
	};

	static public bool isGettingQuest;
	static public int inBooth;

	void Start() {
		rb = GetComponent<Rigidbody>();
		anim = transform.Find("Sprite").GetComponent<Animator>();
		sr = transform.Find("Sprite").GetComponent<SpriteRenderer>();
		isGettingQuest = false;
		inBooth = 0;
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.E)) {
			if (isGettingQuest == true) {
				isGettingQuest = false;
				inBooth = 0;
			} else {
				if (Vector3.Distance(transform.position, boothCoords[0]) <= interactionDistance) {
					isGettingQuest = true;
					inBooth = 1;
				} else if (Vector3.Distance(transform.position, boothCoords[1]) <= interactionDistance) {
					isGettingQuest = true;
					inBooth = 2;
				} else if (Vector3.Distance(transform.position, boothCoords[2]) <= interactionDistance) {
					isGettingQuest = true;
					inBooth = 3;
				} else if (Vector3.Distance(transform.position, boothCoords[3]) <= interactionDistance) {
					isGettingQuest = true;
					inBooth = 4;
				} else if (Vector3.Distance(transform.position, boothCoords[4]) <= interactionDistance) {
					isGettingQuest = true;
					inBooth = 5;
				}
			}
		} else {
			movement.x = Input.GetAxis("Horizontal");
			movement.z = Input.GetAxis("Vertical");

			Vector3 moveDir = new Vector3(movement.x, 0f, movement.z);
			rb.velocity = moveDir * movementSpeed;

			anim.SetFloat("Horizontal", movement.x);
			anim.SetFloat("Vertical", movement.z);
			anim.SetFloat("Speed", movement.sqrMagnitude);
		}
	}
}
