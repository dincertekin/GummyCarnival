using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    static public bool musicMuted = false;
    static public bool soundsMuted = false;
    private AudioSource[] sources;

    void Start()
    {
        sources = GetComponents<AudioSource>();
        for (int i = 0; i < sources.Length; i++)
        {
            sources[i].mute = false;
        }
    }

    void Update()
    {
        sources[0].mute = soundsMuted;
        sources[1].mute = musicMuted;
    }

    public void muteMusic() {
        musicMuted = !musicMuted;
    }

    public void muteSounds() {
        soundsMuted = !soundsMuted;
    }
}
