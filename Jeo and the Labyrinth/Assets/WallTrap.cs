using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrap : MonoBehaviour
{
    public GameObject[] wall;

    private void Start()
    {
        for (int i = 0; i < wall.Length; i++)
            wall[i].SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            for (int i = 0; i < wall.Length; i++)
                wall[i].SetActive(false);
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < wall.Length; i++)
            {
                wall[i].SetActive(true);
                wall[i].GetComponent<Animator>().SetTrigger("Fade");
            }
        }
    }
}
