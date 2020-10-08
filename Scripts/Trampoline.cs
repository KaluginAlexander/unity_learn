using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{

    Animator anim;
    public float cooldown = 1f;

    private void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Upping());
    }

    IEnumerator Upping()
    {
        anim.SetBool("UP", true);
        yield return new WaitForSeconds(cooldown);
        anim.SetBool("UP", false);
    }
}
