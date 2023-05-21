using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame2CharController : MonoBehaviour {
    private Rigidbody2D rb;
    private float movementSpeed = 3f;
    static public int playerScore = 0;

    public GameObject Melon;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 moveDirection = new Vector2(horizontal, vertical);
        rb.velocity = moveDirection * movementSpeed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        if (hitInfo.name == "Melon(Clone)") {
            playerScore += 1;
            Destroy(GameObject.Find("Melon(Clone)"));
            Instantiate(Melon, new Vector3(3.268725f, -2.611593f, 0f), new Quaternion(0f, 0f, 0f, 0f));
        }
    }
}
