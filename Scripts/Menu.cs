using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text coins;
    
    public void LoadSceneByIndex(int i)
    {
        SceneManager.LoadScene(i);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey("level"))
        {
            writeData();
        }

        coins.text = PlayerPrefs.GetInt("coins").ToString();
    }

    void writeData()
    {
        PlayerPrefs.SetInt("level", 1);
        PlayerPrefs.SetInt("coins", 0);
    }
}
