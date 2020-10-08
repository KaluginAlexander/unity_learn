using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    bool isHit = false;
    public GameObject dropItem; 

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player" && !isHit)
        {
            collision.gameObject.GetComponent<Player>().RecountHP(-1);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 8f, ForceMode2D.Impulse);
        }

    }

    public void death()
    {
        StartCoroutine(Dead());
        isHit = true;
    }

    void Drop()
    {
        if (dropItem != null)
        {
            Instantiate(dropItem, new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z), dropItem.GetComponent<Transform>().rotation);
        }
    }


    IEnumerator Dead()
    {

        Drop();

        GetComponent<Animator>().SetBool("death", true);
        GetComponent<GroundPatrol>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.AddForce(Vector3.up * 18f, ForceMode2D.Impulse);

        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}
