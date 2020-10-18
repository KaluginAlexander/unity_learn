using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UB : MonoBehaviour
{

    public Inventory inv;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inv.addUB();
            Destroy(gameObject);
        }
    }
}
