using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bittle : MonoBehaviour
{

    public Transform point;
    public float speed = 1f;
    bool isHidden = false;
    bool isWait = true;
    public float timeToWait = 4f;


    // Start is called before the first frame update
    void Start()
    {
        point.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        StayOrAttack();
    }

    void StayOrAttack()
    {
        if (!isWait)
        {
            transform.position = Vector3.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
        }
        
        if (transform.position == point.position)
        {

            if (isHidden)
            {
                point.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
                isHidden = false;
            }
            else
            {
                point.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
                isHidden = true;
            }

            isWait = true;
            StartCoroutine(Waiting());
        }
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(timeToWait);
        isWait = false;
    }
}
