using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public door toDoor;
    public GameObject doorTop;
    public Sprite top, mid;
    public bool isOpen = false;
    float TeleportCooldown = 0.3f;
    public GameObject player;

    public void Unlock()
    {

        // Change sprites
        doorTop.GetComponent<SpriteRenderer>().sprite = top;
        GetComponent<SpriteRenderer>().sprite = mid;

        StartCoroutine(SetCooldown());

        isOpen = true;
        
    }

    public void Teleport()
    {
        
        TeleportPlayer();
        StartCoroutine(SetCooldown());
    }

    IEnumerator SetCooldown()
    {
        Player playerScript = player.GetComponent<Player>();
        playerScript.isDoorWait = true;
        yield return new WaitForSeconds(TeleportCooldown);
        playerScript.isDoorWait = false;

    }

    void TeleportPlayer()
    {
        if (!toDoor.isOpen)
            toDoor.Unlock();

        Player playerScript = player.GetComponent<Player>();
        playerScript.transform.position = new Vector3(toDoor.transform.position.x, toDoor.transform.position.y, playerScript.transform.position.z);

        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
    }

    
 
}
