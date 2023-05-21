using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Minigame1CharacterController2D : MonoBehaviour {
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private AudioSource[] sources;

    private float movementSpeed = 3f;
    static public int playerScore = 0;
    static public float timeLeft = 59;
    private bool playerDidObjective = false;

    public GameObject enemyPrefab;
    public GameObject successText;
    public Text successTextComponent;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        sources = GetComponents<AudioSource>();
        if (!GameController.musicMuted) {
            sources[1].Play();
        }
        successTextComponent = successText.GetComponent<Text>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!GameController.gamePaused) {
                GameController.pauseGame();
            } else {
                GameController.resumeGame();
            }
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            successTextComponent.enabled = false;
            if (playerDidObjective == true) {
                CharacterController.hasGotStrawberryGum = 1;
                SceneManager.LoadScene("MainGameScene");
            } else {
                GameController.resumeGame();
                timeLeft = 59;
                playerScore = 0;
                GameObject.Find("scoreText").GetComponent<Text>().text = playerScore.ToString()+"/50";
                Destroy(GameObject.Find("Enemy"));
                Destroy(GameObject.Find("Enemy(Clone)"));
                Instantiate(enemyPrefab, new Vector3(9.49f, Random.Range(-1.99f, -3.19618f), 0f), new Quaternion(0f, 0f, 0f, 0f));
            }
        }

        if (Input.GetButtonDown("Fire1") && !GameController.soundMuted) {
            sources[0].Play();
        }

        if (timeLeft <= 0) {
            GameObject.Find("timeText").GetComponent<Text>().text = "00:00";
            if (playerScore >= 50) {
                playerDidObjective = true;
                GameController.pauseGame();
                successTextComponent.enabled = true;
                successTextComponent.text = "BASARDIN!\nKARNAVALA DONMEK ICIN 'R' BAS.";
            } else {
                playerDidObjective = false;
                GameController.pauseGame();
                successTextComponent.enabled = true;
                successTextComponent.text = "BASARAMADIN!\nTEKRAR DENEMEK ICIN 'R' BAS.";
            }
        } else {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 10) {
                GameObject.Find("timeText").GetComponent<Text>().text = "00:0"+timeLeft.ToString("0");
            } else {
                GameObject.Find("timeText").GetComponent<Text>().text = "00:"+timeLeft.ToString("0");
            }
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 moveDirection = new Vector2(horizontal, vertical);
        rb.velocity = moveDirection * movementSpeed;

        if (horizontal != 0 && horizontal > 0) {
            sr.flipX = false;
            anim.SetBool("isRunning", true);
        } else if (horizontal != 0 && horizontal < 0) {
            sr.flipX = true;
            anim.SetBool("isRunning", true);
        } else {
            anim.SetBool("isRunning", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Enemy" || collision.gameObject.name == "Enemy(Clone)") {
            playerDidObjective = false;
            GameController.pauseGame();
            successTextComponent.enabled = true;
            successTextComponent.text = "BASARAMADIN!\nTEKRAR DENEMEK ICIN 'R' BAS.";
        }
    }
}
