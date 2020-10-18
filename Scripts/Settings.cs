using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{

    public Slider music, sound;
    float lastValueMusic, lastValueSound;

    void Start()
    {
        music.value = PlayerPrefs.GetFloat("musicValue");
        sound.value = PlayerPrefs.GetFloat("soundValue");
    }

    public void updateSoundValue()
    {
        PlayerPrefs.SetFloat("soundValue", sound.value);
    }


    public void updateMusicValue()
    {
        PlayerPrefs.SetFloat("musicValue", music.value);
    }
}
