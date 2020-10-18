using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB : MonoBehaviour
{

    public Inventory inv;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inv.addSB();
            Destroy(gameObject);
        }
    }
}
