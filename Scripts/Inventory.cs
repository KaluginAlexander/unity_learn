using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Player player;
    public Sprite eHB, fHB, eSB, fSB, eUB, fUB;
    public Image imageHB, imageSB, imageUB;
    public Text textHB, textSB, textUB;
    int HB, SB, UB;

    // Start is called before the first frame update
    void Start()
    {
        HB = PlayerPrefs.GetInt("HB");
        SB = PlayerPrefs.GetInt("SB");
        UB = PlayerPrefs.GetInt("UB");
    
        if (HB > 0)
        {
            imageHB.sprite = fHB;
        }

        if (SB > 0)
        {
            imageSB.sprite = fSB;
        }

        if (UB > 0)
        {
            imageUB.sprite = fUB;
        }

        textHB.text = HB.ToString();
        textSB.text = SB.ToString();
        textUB.text = UB.ToString();
    }


    public void useHB()
    {
        if (HB > 0)
        {
            player.addHealthEffect();
            HB -= 1;
            PlayerPrefs.SetInt("HB", PlayerPrefs.GetInt("HB") - 1);
        }

        textHB.text = HB.ToString();

        if (HB == 0)
        {
            imageHB.sprite = eHB;
        }
    }

    public void useSB()
    {
        if (SB > 0)
        {
            player.addSpeedEffect();
            PlayerPrefs.SetInt("SB", PlayerPrefs.GetInt("SB") - 1);
            SB -= 1;
        }

        textSB.text = SB.ToString();

        if (SB == 0)
        {
            imageSB.sprite = eSB;
        }
    }

    public void useUB()
    {
        if (UB > 0)
        {
            player.addUnhitEffect(); 
            UB -= 1;
            PlayerPrefs.SetInt("UB", PlayerPrefs.GetInt("UB") - 1);
        }

        textUB.text = UB.ToString();

        if (UB == 0)
        {
            imageUB.sprite = eUB;
        }
    }

    public void addHB()
    {
        HB++;
        PlayerPrefs.SetInt("HB", PlayerPrefs.GetInt("HB") + 1);
        textHB.text = HB.ToString();
        imageHB.sprite = fHB;
    }

    public void addUB()
    {
        UB++;
        PlayerPrefs.SetInt("UB", PlayerPrefs.GetInt("UB") + 1);
        textUB.text = UB.ToString();
        imageUB.sprite = fUB;
    }

    public void addSB()
    {
        SB++;
        PlayerPrefs.SetInt("SB", PlayerPrefs.GetInt("SB") + 1);
        textSB.text = SB.ToString();
        imageSB.sprite = fSB;
    }

}
