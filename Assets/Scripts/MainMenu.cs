using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public Sprite deetaGumBoxOff;
	public Sprite deetaGumBoxOn;
	private Image image;

    void Start() {
		image = GetComponent<Image>();
	}

    public void openThePandorasBox() {
        image.sprite = deetaGumBoxOn;
    }

    public void closeThePandorasBox() {
        image.sprite = deetaGumBoxOff;
    }

    public void playButtonClicked() {
		SceneManager.LoadScene("MainGameScene");
	}

	public void optionsButtonClicked() {
		SceneManager.LoadScene("OptionsMenuScene");
	}

	public void quitButtonClicked() {
		Application.Quit();
	}
}