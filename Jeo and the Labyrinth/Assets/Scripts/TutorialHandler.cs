using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// The GO moves around the scene and displays the information at the right time.
public class TutorialHandler : MonoBehaviour
{
    // Each element is a GO which displays some kind of information.
    public GameObject[] canvasElement;

    // Array of positions
    public Transform[] whereToGo;

    // We use this to know which info we need to display.
    private int m_CurrentStage = 0;

    private void Start()
    {
        transform.position = whereToGo[0].position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (m_CurrentStage >= whereToGo.Length)
            {
                Destroy(gameObject);
                return;
            }
            // We display the information.
            canvasElement[m_CurrentStage++].GetComponent<Animator>().SetTrigger("Play");
            // We move to the next position.
            transform.position = whereToGo[m_CurrentStage].position;
        }
    }
}
