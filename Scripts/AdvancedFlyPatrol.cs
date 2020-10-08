using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedFlyPatrol : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform[] points;
    public float timeToWait = 1f;
    public float speed = 3f;
    bool isCanGo = true;
    int el = 1;

    void Start()
    {
        transform.position = new Vector3(points[0].position.x, points[0].position.y, points[0].position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (isCanGo)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[el].position, speed * Time.deltaTime);
        }

        if (transform.position == points[el].position)
        {
            if (el < points.Length - 1)
            {
                el += 1;
            }

            else
            {
                el = 0;
            }

            isCanGo = false;
            StartCoroutine(Waiting());
        }
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(timeToWait);
        isCanGo = true;
    }
}
