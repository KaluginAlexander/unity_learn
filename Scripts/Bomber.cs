using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour
{

    public GameObject bullet;
    public Transform shoot;
    public float interval = 2f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shooting());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Shooting()
    {

        yield return new WaitForSeconds(interval);
        StartCoroutine(Shooting());
        Instantiate(bullet, shoot.transform.position, transform.rotation);
    }
}
