using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour {
    public Rigidbody2D rb;
    public float speed = 20f;
    public GameObject enemyPrefab;

    void Start() {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        if (hitInfo.name == "Enemy" || hitInfo.name == "Enemy(Clone)") {
            Destroy(hitInfo.gameObject);
            Instantiate(enemyPrefab, new Vector3(9.49f, Random.Range(-1.99f, -3.19618f), 0f), new Quaternion(0f, 0f, 0f, 0f));
            CharacterController2D.playerScore += 1;
            GameObject.Find("scoreText").GetComponent<Text>().text = CharacterController2D.playerScore.ToString()+"/50";
        }
        Destroy(gameObject);
    }
}
