using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource music;
    public AudioSource sound;

    void Update()
    {
        music.volume = PlayerPrefs.GetFloat("musicValue");
        sound.volume = PlayerPrefs.GetFloat("soundValue");
    }
}
