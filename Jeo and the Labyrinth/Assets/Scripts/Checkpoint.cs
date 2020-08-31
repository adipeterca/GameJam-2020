using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject checkpointText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has passed though a checkpoint!");

            // Animate the checkpoint text
            checkpointText.SetActive(true);
            checkpointText.GetComponent<Animator>().SetTrigger("Passed");
            // Destroy this GO so the GameManager will only retain its position.
            GameManager.ChangeCheckpointPosition(transform.position);
            Destroy(gameObject);
        }
    }
}
