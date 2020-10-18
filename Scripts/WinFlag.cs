using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinFlag : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().main.getWin();

            if (PlayerPrefs.GetInt("level") <= SceneManager.GetActiveScene().buildIndex)
            {
                addLevel();
            }

        }
    }

    void addLevel()
    {
        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
    }
}
