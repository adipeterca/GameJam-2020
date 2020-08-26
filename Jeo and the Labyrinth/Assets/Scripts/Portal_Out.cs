using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_Out : MonoBehaviour
{
    public float rotationSpeed;

    private void Update()
    {
        transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime * rotationSpeed);
    }
}
