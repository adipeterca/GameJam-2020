using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_In : MonoBehaviour
{
    public Transform outPortal;
    public float rotationSpeed;

    private void Update()
    {
        transform.Rotate(new Vector3(0, 45f, 0) * rotationSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = outPortal.position + new Vector3(0, 0.5f, 0);
        }
    }
}
