using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public void BuyHealth(int cost)
    {
        int money = PlayerPrefs.GetInt("coins");

        if (money >= cost)
        {
            PlayerPrefs.SetInt("coins", money - cost);
            PlayerPrefs.SetInt("HB", PlayerPrefs.GetInt("HB") + 1);

            updateBalance();
        }
    }

    public void BuySpeed(int cost)
    {
        int money = PlayerPrefs.GetInt("coins");

        if (money >= cost)
        {
            PlayerPrefs.SetInt("coins", money - cost);
            PlayerPrefs.SetInt("SB", PlayerPrefs.GetInt("SB") + 1);

            updateBalance();
        }
    }

    public void BuyUnhit(int cost)
    {
        int money = PlayerPrefs.GetInt("coins");

        if (money >= cost)
        {
            PlayerPrefs.SetInt("coins", money - cost);
            PlayerPrefs.SetInt("UB", PlayerPrefs.GetInt("UB") + 1);

            updateBalance();
        }
    }

    void updateBalance()
    {
        GetComponent<Menu>().updateShopTitles();
    }
}
