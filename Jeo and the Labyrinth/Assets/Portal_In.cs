using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_In : MonoBehaviour
{
    public Transform outPortal; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = outPortal.position;
        }
    }
}
