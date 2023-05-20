using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
	public float movementSpeed = 4f;
	public Rigidbody rb;
    public float interactionDistance = 3f;

	public Animator anim;
	public SpriteRenderer sr;
	Vector3 movement;

	public Vector3[] boothCoords = new Vector3[] {
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
			} else {
				if (Vector3.Distance(transform.position, boothCoords[0]) <= interactionDistance) {
					Debug.Log("Stand 1 yakınında E basıldı.");
					isGettingQuest = true;
					inBooth = 1;
				} else if (Vector3.Distance(transform.position, boothCoords[1]) <= interactionDistance) {
					Debug.Log("Stand 2 yakınında E basıldı.");
					isGettingQuest = true;
					inBooth = 2;
				} else if (Vector3.Distance(transform.position, boothCoords[2]) <= interactionDistance) {
					Debug.Log("Stand 3 yakınında E basıldı.");
					isGettingQuest = true;
					inBooth = 3;
				} else if (Vector3.Distance(transform.position, boothCoords[3]) <= interactionDistance) {
					Debug.Log("Stand 4 yakınında E basıldı.");
					isGettingQuest = true;
					inBooth = 4;
				} else if (Vector3.Distance(transform.position, boothCoords[4]) <= interactionDistance) {
					Debug.Log("Stand 5 yakınında E basıldı.");
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
