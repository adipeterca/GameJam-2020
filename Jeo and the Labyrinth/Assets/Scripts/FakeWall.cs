using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeWall : MonoBehaviour
{
    Animator anim;
    bool passed = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") || passed)
            return;

        passed = true;
        anim.SetTrigger("Fade");
        Destroy(gameObject, 2.1f);
    }
}
