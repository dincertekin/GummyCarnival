using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	static public bool musicMuted = false;
	static public bool soundsMuted = false;
	static public AudioSource[] sources;
	public GameObject sesButonu;
	public GameObject muzikButonu;
	public Sprite sesAcikButonu;
	public Sprite sesKapaliButonu;
	public Sprite muzikAcikButonu;
	public Sprite muzikKapaliButonu;

	void Start() {
		sources = GetComponents<AudioSource>();
		for (int i = 0; i < sources.Length; i++) {
			sources[i].mute = false;
		}
		sesButonu.GetComponent<Image>().sprite = sesAcikButonu;
		muzikButonu.GetComponent<Image>().sprite = muzikAcikButonu;
	}

	void Update() {
		sources[0].mute = soundsMuted;
		sources[1].mute = musicMuted;
	}

	public void muteMusic() {
		if (musicMuted == false) {
			musicMuted = true;
			muzikButonu.GetComponent<Image>().sprite = muzikKapaliButonu;
		} else {
			musicMuted = false;
			muzikButonu.GetComponent<Image>().sprite = muzikAcikButonu;
		}
	}

	public void muteSounds() {
		if (soundsMuted == false) {
			soundsMuted = true;
			sesButonu.GetComponent<Image>().sprite = sesKapaliButonu;
		} else {
			soundsMuted = false;
			sesButonu.GetComponent<Image>().sprite = sesAcikButonu;
		}
	}

	public static void setMusicVolume(float volumeValue) {
		sources[1].volume = volumeValue;
	}

	public static void setSoundsVolume(float volumeValue) {
		Debug.Log("TEST TDSSD FDSDS FSD" + sources[0].volume);
		sources[0].volume = volumeValue;
	}
}