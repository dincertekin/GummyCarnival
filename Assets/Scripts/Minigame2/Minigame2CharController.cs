using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame2CharController : MonoBehaviour {
    private Rigidbody2D rb;
    private float movementSpeed = 3f;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 moveDirection = new Vector2(horizontal, vertical);
        rb.velocity = moveDirection * movementSpeed;
    }
}
