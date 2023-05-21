using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public Rigidbody2D rb;
    public float speed = 3f;

    void Start() {
        rb.velocity = (transform.right * -1) * speed;
    }
}
