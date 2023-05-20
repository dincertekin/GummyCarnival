using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMsgBoxController : MonoBehaviour {
    private Canvas CanvasObject;
    public GameObject PopupMessageBoxText;
    private Text TextValue;

    void Start() {
        CanvasObject = GetComponentInParent<Canvas>();
        TextValue = PopupMessageBoxText.GetComponent<Text>();
    }

    void Update() {
        if (CharacterController.isGettingQuest == true) {
            if (CharacterController.inBooth != 0) {
                CanvasObject.enabled = true;
                if (CharacterController.inBooth == 1) {
                    TextValue.text = "Cikardim on numarali formami, hatta formam bile kaskati kesildi... Simdi, oyun icin hazir misin? Naneli sakiz ferahliginda heyecan dolu bir deneyim seni bekliyor. Hadi, birlikte bu essiz deneyime adim atalim ve kazanmak icin her seyi yapalim!";
                }
                else if (CharacterController.inBooth == 2) {
                    TextValue.text = "Sicak havada serinlemenin en iyi yolu Maras dondurmasidir. Tabii ki burda dondurma yok! Mersinin yabanlarindan gelen yaban mersinli sakizi denemek icin oyuna var misin?";
                }
                else if (CharacterController.inBooth == 3) {
                    TextValue.text = "3. stand yazisi";
                }
                else if (CharacterController.inBooth == 4) {
                    TextValue.text = "4. stand yazisi";
                }
                else if (CharacterController.inBooth == 5) {
                    TextValue.text = "5. stand yazisi";
                }
            }
        } else {
            CanvasObject.enabled = false;
        }
    }
}
