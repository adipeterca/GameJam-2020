using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpOptions : MonoBehaviour
{
    [Range (0.01f, 10.0f)]
    public float rotationMultiplier = 1f;
    [Range(0.01f, 2.0f)]
    public float upDownMultiplier = 1f;
    public int points;
    public GameManager gameManager;

    Vector3 downPos, upPos;
    bool goUp = true;

    private void Start()
    {
        downPos = transform.position - new Vector3(0, 0.75f, 0);
        upPos = -downPos;
    }

    private void Update()
    {
        transform.Rotate(0, 45f * Time.deltaTime * rotationMultiplier, 0);
        if (transform.position.y >= upPos.y)
            goUp = false;
        if (transform.position.y <= downPos.y)
            goUp = true;

        if (goUp)
            transform.position += new Vector3(0f, 1f, 0f) * upDownMultiplier * Time.deltaTime;
        else
            transform.position -= new Vector3(0f, 1f, 0f) * upDownMultiplier * Time.deltaTime;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.AddPoints(points);
            Destroy(gameObject);
        }
    }

}
