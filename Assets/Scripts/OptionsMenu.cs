using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour {
	public GameObject soundSlider;
	public GameObject musicSlider;

	public void sendSoundVolume() {
		Debug.Log(soundSlider.GetComponent<Slider>().value);
		GameController.setSoundVolume(soundSlider.GetComponent<Slider>().value);
	}

	public void sendMusicVolume() {
		Debug.Log(musicSlider.GetComponent<Slider>().value.GetType().Name);
		GameController.setMusicVolume(musicSlider.GetComponent<Slider>().value);
	}

	public void backToMainMenu() {
		SceneManager.LoadScene("MainMenuScene");
	}
}