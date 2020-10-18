using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffector : MonoBehaviour
{
    public AudioSource sounder;
    public AudioClip win, lose, coinTake;

    public void playWin()
    {
        sounder.PlayOneShot(win);
    }

    public void playLose()
    {
        sounder.PlayOneShot(lose);
    }

    public void playCoinTake()
    {
        sounder.PlayOneShot(coinTake);
    }
}
