using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuItem : MonoBehaviour
{
	public Sprite deetaSakizKutuKapali;
	public Sprite deetaSakizKutuAcik;
	private Image image;

	void Start()
	{
		image = GetComponent<Image>();
	}

	public void playButtonClicked() {
		SceneManager.LoadScene("MainGameScene");
	}

	public void optionsButtonClicked() {
		Debug.Log("Open Options");
	}

	public void quitButtonClicked() {
		Application.Quit();
	}

	public void openThePandorasBox() {
		image.sprite = deetaSakizKutuAcik;
	}

	// public void closeThePandorasBox() {
	// 	image.sprite = deetaSakizKutuKapali;
	// }
}
