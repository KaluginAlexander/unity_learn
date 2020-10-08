using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    float length, startpos;
    public GameObject cam;
    public float paralaxEffect;
    float dist, temp;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        dist = cam.transform.position.x * paralaxEffect;
        temp = cam.transform.position.x * (1 - paralaxEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + length)
        {
            startpos += length;
        }
        
        else if (temp < startpos - length)
        {
            startpos -= length;
        }
    }
}
