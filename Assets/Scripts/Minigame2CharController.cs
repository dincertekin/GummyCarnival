using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Minigame2CharController : MonoBehaviour {
    private Rigidbody2D rb;
    private float movementSpeed = 3f;
    
    static public int playerScore = 0;
    static public float timeLeft = 59;
    private bool playerDidObjective = false;

    public GameObject successText;
    public Text successTextComponent;

    public GameObject Melon;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
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
                CharacterController.hasGotMelonGum = 1;
                SceneManager.LoadScene("MainGameScene");
            } else {
                GameController.resumeGame();
                timeLeft = 59;
                playerScore = 0;
                Destroy(GameObject.Find("Melon(Clone)"));
                Instantiate(Melon, new Vector3(3.268725f,  Random.Range(-2.36f, -4.67f), 0f), new Quaternion(0f, 0f, 0f, 0f));
            }
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
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        if (hitInfo.name == "Melon(Clone)") {
            playerScore += 1;
            GameObject.Find("scoreText").GetComponent<Text>().text = playerScore.ToString()+"/50";
            Destroy(GameObject.Find("Melon(Clone)"));
            Instantiate(Melon, new Vector3(3.268725f,  Random.Range(-2.36f, -4.67f), 0f), new Quaternion(0f, 0f, 0f, 0f));
        }
    }
}
