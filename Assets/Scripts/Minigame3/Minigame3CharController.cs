using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Minigame3CharController : MonoBehaviour {
    private Rigidbody2D rb;
    private float movementSpeed = 3f;
    
    static public int playerScore = 0;
    private float timeLeft = 59;
    private bool playerDidObjective = false;

    public GameObject ball;
    public Rigidbody2D ballRigidbody;
    public GameObject successText;
    public Text successTextComponent;


    void Start() {
        rb = GetComponent<Rigidbody2D>();
        successTextComponent = successText.GetComponent<Text>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            successTextComponent.enabled = false;
            if (playerDidObjective == true) {
                CharacterController.hasGotMintGum = 1;
                SceneManager.LoadScene("MainGameScene");
            } else {
                GameController.resumeGame();
                timeLeft = 59;
                playerScore = 0;
                GameObject.Find("Ball").transform.position = new Vector3(0f, 3.40f, 0f);
            }
        }

        if (timeLeft <= 0) {
            GameObject.Find("timeText").GetComponent<Text>().text = "00:00";
            if (playerScore >= 30) {
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

        Vector2 moveDirection = new Vector2(horizontal, 0f);
        rb.velocity = moveDirection * movementSpeed;
    }

    void OnCollisionEnter2D(Collision2D hitInfo) {
        if (hitInfo.gameObject.name == "Ball") {
            playerScore += 1;
            GameObject.Find("scoreText").GetComponent<Text>().text = playerScore.ToString()+"/30";
            ballRigidbody.velocity = ball.transform.up * 10f;
        }
    }
}
