using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour {
	public float movementSpeed = 4f;
    public float interactionDistance = 3f;

	public Rigidbody rb;
	public Animator anim;
	public SpriteRenderer sr;
	private Vector3 movement;
	private AudioSource footsteps;

	static public bool isGettingQuest;
	static public int inBooth;

	static public int hasGotMintGum = 0;
	static public int hasGotBlueberryGum = 0;
	static public int hasGotStrawberryGum = 0;
	static public int hasGotMelonGum = 0;
	// static public int hasGotBlackberryGum = 0;

	static public int gameEnd = 0;

	private Vector3[] boothCoords = new [] {
		new Vector3(5.95f, 1.58f, -10.5f),
		new Vector3(14.95f, 1.58f, -10.5f),
		new Vector3(23.97f, 1.58f, -10.5f),
		new Vector3(33.16f, 1.58f, -10.5f),
		new Vector3(41.55f, 1.58f, -10.5f)
	};

	void Start() {
		GameController.resumeGame();
		rb = GetComponent<Rigidbody>();
		anim = transform.Find("playerSprite").GetComponent<Animator>();
		sr = transform.Find("playerSprite").GetComponent<SpriteRenderer>();
		footsteps = GetComponent<AudioSource>();
		isGettingQuest = false;
		inBooth = 0;
	}

	void Update() {
		GameObject.Find("mintGumText").GetComponent<Text>().text = hasGotMintGum.ToString()+"x";
		GameObject.Find("blueberryGumText").GetComponent<Text>().text = hasGotBlueberryGum.ToString()+"x";
		GameObject.Find("strawberryGumText").GetComponent<Text>().text = hasGotStrawberryGum.ToString()+"x";
		GameObject.Find("melonGumText").GetComponent<Text>().text = hasGotMelonGum.ToString()+"x";
		// GameObject.Find("blackberryGumText").GetComponent<Text>().text = hasGotBlackberryGum.ToString()+"x";

		if (hasGotMintGum == 1 && hasGotBlueberryGum == 1 && hasGotStrawberryGum == 1 && hasGotMelonGum == 1) { // hasGotBlackBerryGum
			gameEnd = 1;
		}
		
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

			if (movement.x != 0 || movement.z != 0) {
				footsteps.enabled = true;
			} else {
				footsteps.enabled = false;
			}

			Vector3 moveDirection = new Vector3(movement.x, 0f, movement.z);
			rb.velocity = moveDirection * movementSpeed;

			anim.SetFloat("Horizontal", movement.x);
			anim.SetFloat("Vertical", movement.z);
			anim.SetFloat("Speed", movement.sqrMagnitude);
		}
	}
}
