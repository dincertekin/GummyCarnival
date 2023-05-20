using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {
	public GameObject sesSlider;
	public GameObject muzikSlider;

	public void sendSoundVolume() {
		Debug.Log(sesSlider.GetComponent<Slider>().value);
		GameController.setSoundsVolume(sesSlider.GetComponent<Slider>().value);
	}

	public void sendMusicVolume() {
		Debug.Log(muzikSlider.GetComponent<Slider>().value);
		GameController.setMusicVolume(muzikSlider.GetComponent<Slider>().value);
	}
}