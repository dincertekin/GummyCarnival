using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame2Melon : MonoBehaviour {
    private Rigidbody2D rb;
    private float speed = 3f;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = (transform.right * -1) * speed;
    }
}
