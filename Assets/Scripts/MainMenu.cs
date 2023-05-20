using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public Sprite deetaSakizKutuKapali;
	public Sprite deetaSakizKutuAcik;
	private Image image;

    void Start() {
		image = GetComponent<Image>();
	}

    public void openThePandorasBox() {
        image.sprite = deetaSakizKutuAcik;
    }

    public void closeThePandorasBox() {
        image.sprite = deetaSakizKutuKapali;
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