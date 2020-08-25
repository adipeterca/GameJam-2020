using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_Camera : MonoBehaviour
{
    public Transform cube;
    public float speed;

    private void Update()
    {
        transform.RotateAround(cube.position, Vector3.up, speed);
        transform.LookAt(cube);
    }
}
