using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Main : MonoBehaviour
{

    public GameObject pausePanel, pause, winPanel;
    public Text coins;
    public Player player;
    public Image[] hearts;
    public Sprite LifeTrue, LifeFalse, keyTrue, keyFalse;
    public Image key;

    private void Update()
    {
        updateCoins();
        updateKey();
        updateHearts();
    }

    void updateCoins()
    {
        coins.text = player.getCoins().ToString();
    }

    void updateKey()
    {
        if (player.haveKey)
            key.sprite = keyTrue;
        else
            key.sprite = keyFalse;
    }

    void updateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (player.getHP() < i + 1)
                hearts[i].sprite = LifeFalse;
            else
                hearts[i].sprite = LifeTrue;
        }
    }

    public void Lose()
    {
        Restart();
        Play();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void goToMenu () 
    {
        SceneManager.LoadScene(0);
    }


    public void Play()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        pause.SetActive(true);
    }


    public void Pause()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        pause.SetActive(false);
    }

    public void getWin()
    {
        Time.timeScale = 0f;
        winPanel.SetActive(true);
        pause.SetActive(false);
    }

    public void Next()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }
}
