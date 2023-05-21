using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame2MelonMan : MonoBehaviour {
    private SpriteRenderer sr;
    public Sprite melonman1;
    public Sprite melonman2;

    public GameObject Melon;

    void Start() {
        sr = GetComponent<SpriteRenderer>();
        MelonThrow();
    }

    void MelonThrow() {
        sr.sprite = melonman2;
        Instantiate(Melon, new Vector3(3.268725f, -2.611593f, 0f), new Quaternion(0f, 0f, 0f, 0f));
    }
}