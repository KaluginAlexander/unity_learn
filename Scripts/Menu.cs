using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text[] coins;
    public GameObject[] levels;

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

        updateShopTitles();
        
    }

    public void updateShopTitles()
    {
        foreach (Text coin in coins)
        {
            coin.text = PlayerPrefs.GetInt("coins").ToString();
        }
    }

    private void Update()
    {
        updateLevelsLocking();
    }

    void writeData()
    {
        PlayerPrefs.SetInt("level", 1);
        PlayerPrefs.SetInt("coins", 0);
        PlayerPrefs.SetInt("PB", 0);
        PlayerPrefs.SetInt("HB", 0);
        PlayerPrefs.SetInt("SB", 0);
        PlayerPrefs.SetFloat("musicValue", 0.5f);
        PlayerPrefs.SetFloat("soundValue", 1f);
    }

    void updateLevelsLocking()
    {

        int complitedLevels = PlayerPrefs.GetInt("level");

        int index = 0;

        foreach(GameObject level in levels)
        {
            index += 1;

            if (index > complitedLevels)
            {
                level.SetActive(false);
            }
        }
    }

}
