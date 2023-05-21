using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	static public bool musicMuted = false;
	static public bool soundMuted = false;
	static public bool gamePaused = false;

	static public AudioSource[] audioSources;

	public GameObject soundToggleButton;
	public GameObject musicToggleButton;

	public Sprite soundButtonON;
	public Sprite soundButtonOFF;
	public Sprite musicButtonON;
	public Sprite musicButtonOFF;

	void Start() {
		audioSources = GetComponents<AudioSource>();
		for (int i = 0; i < audioSources.Length; i++) {
			audioSources[i].mute = false;
		}
		soundToggleButton.GetComponent<Image>().sprite = soundButtonON;
		musicToggleButton.GetComponent<Image>().sprite = musicButtonON;
	}

	void Update() {
		audioSources[0].mute = soundMuted;
		audioSources[1].mute = musicMuted;
	}

	public void muteMusic() {
		if (musicMuted == false) {
			musicMuted = true;
			musicToggleButton.GetComponent<Image>().sprite = musicButtonOFF;
		} else {
			musicMuted = false;
			musicToggleButton.GetComponent<Image>().sprite = musicButtonON;
		}
	}

	public void muteSounds() {
		if (soundMuted == false) {
			soundMuted = true;
			soundToggleButton.GetComponent<Image>().sprite = soundButtonOFF;
		} else {
			soundMuted = false;
			soundToggleButton.GetComponent<Image>().sprite = soundButtonON;
		}
	}

	public static void setMusicVolume(float volumeValue) {
		audioSources[1].volume = volumeValue;
	}

	public static void setSoundVolume(float volumeValue) {
		audioSources[0].volume = volumeValue;
	}

	public static void pauseGame() {
		gamePaused = true;
		Time.timeScale = 0;
	}

	public static void resumeGame() {
		gamePaused = false;
		Time.timeScale = 1;
	}
}