using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuItem : MonoBehaviour
{
    public Sprite deetaSakizKutuKapali;
	public Sprite deetaSakizKutuAcik;
	private Image image;

    void Start()
	{
		image = GetComponent<Image>();
	}

    public void openThePandorasBox() {
        image.sprite = deetaSakizKutuAcik;
    }

    public void closeThePandorasBox() {
        image.sprite = deetaSakizKutuKapali;
    }
}
