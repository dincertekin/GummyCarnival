using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMsgBoxController : MonoBehaviour {
	private Canvas canvasObject;
	public GameObject popupMessageBoxText;
	private Text textValue;

	void Start() {
		canvasObject = GetComponentInParent<Canvas>();
		textValue = popupMessageBoxText.GetComponent<Text>();
	}

	void Update() {
		if (CharacterController.isGettingQuest == true) {
			if (CharacterController.inBooth != 0) {
				canvasObject.enabled = true;
				if (CharacterController.inBooth == 1) {
					textValue.text = "Cikardim on numarali formami, hatta formam bile kaskati kesildi... Simdi, oyun icin hazir misin? Naneli sakiz ferahliginda heyecan dolu bir deneyim seni bekliyor. Hadi, birlikte bu essiz deneyime adim atalim ve kazanmak icin her seyi yapalim!";
				}
				else if (CharacterController.inBooth == 2) {
					textValue.text = "Sicak havada serinlemenin en iyi yolu Maras dondurmasidir. Tabii ki burda dondurma yok! Mersinin yabanlarindan gelen yaban mersinli sakizi denemek icin oyuna var misin?";
				}
				else if (CharacterController.inBooth == 3) {
					textValue.text = "Oovv oovv cekilin yoldan vahsi batidan geliyorlar. Amerikanlar eskidi bunlar Turkish cilekler.. Burun kivirtan sakizli macerayi deneyimlemen icin bekliyoruz.";
				}
				else if (CharacterController.inBooth == 4) {
					textValue.text = "Karpuz cekirdeklerinin o guzelim karpuzunu yerken araya girmesi kadar tat bozan bir oyuna var misin?";
				}
				else if (CharacterController.inBooth == 5) {
					textValue.text = "Salih abinin bana yaptigi yolluk kadar uzun soluklu bohohurgtlen sakizli kucuk oyuna katil!";
				}
			}
		} else {
			canvasObject.enabled = false;
		}
	}

	public static void onClick() {
		if (CharacterController.isGettingQuest == true) {
			if (CharacterController.inBooth != 0) {
				if (CharacterController.inBooth == 3) {
					SceneManager.LoadScene("Minigame1Scene");
				}
			}
		}
	}
}
