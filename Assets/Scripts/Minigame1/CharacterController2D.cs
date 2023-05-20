using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private float speed = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 moveDirection = new Vector2(horizontal, vertical);
        rb.velocity = moveDirection * speed;

        if (horizontal != 0 && horizontal < 0) {
            sr.flipX = true;
        } else if (horizontal != 0 && horizontal > 0) {
            sr.flipX = false;
        }
    }
}
