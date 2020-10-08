using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    public GameObject[] arrayObjects;
    public Sprite pressedButton;

    void removeObjectsInArray()
    {
        foreach (GameObject obj in arrayObjects)
        {
            Destroy(obj);  
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = pressedButton;
        removeObjectsInArray();
    }

}
