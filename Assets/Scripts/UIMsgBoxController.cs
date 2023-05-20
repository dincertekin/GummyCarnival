using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMsgBoxController : MonoBehaviour
{
    private Canvas CanvasObject;
    public GameObject PopupMessageBoxText;
    private Text TextValue;

    void Start() {
        CanvasObject = GetComponentInParent<Canvas>();
        TextValue = PopupMessageBoxText.GetComponent<Text>();
    }

    void Update()
    {
        if (CharacterController.isGettingQuest == true) {
            if (CharacterController.inBooth != 0) {
                CanvasObject.enabled = true;
                if (CharacterController.inBooth == 1) {
                    TextValue.text = "1. stand yazisi";
                }
                if (CharacterController.inBooth == 2) {
                    TextValue.text = "2. stand yazisi";
                }
                if (CharacterController.inBooth == 3) {
                    TextValue.text = "3. stand yazisi";
                }
                if (CharacterController.inBooth == 4) {
                    TextValue.text = "4. stand yazisi";
                }
                if (CharacterController.inBooth == 5) {
                    TextValue.text = "5. stand yazisi";
                }
            }
        } else {
            CanvasObject.enabled = false;
        }
    }
}
