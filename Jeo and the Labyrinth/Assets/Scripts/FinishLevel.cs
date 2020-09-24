using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public GameObject finishedLevelCanvas;
    // In which direction should the player keep moving?
    public Direction dir;
    // At what rate?
    public float moveSpeed;
    // CameraMovement reference
    public CameraMovement cameraM;
    // PlayerMovement reference
    public PlayerMovement playerM;


    // Is the game finished?
    private bool finished = false;
    

    public bool IsGameFinished()
    {
        return finished;
    }

    private void Update()
    {
        if (IsGameFinished())
        {
            // playerM.MovePlayerWithSpeed(dir, moveSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Mark the level as finished
            finished = true;

            // Animate the canvas
            finishedLevelCanvas.SetActive(true);
            finishedLevelCanvas.GetComponent<Animator>().SetTrigger("FinishedLevel");

            // Make the player move away from the camera
            cameraM.FollowPlayer = false;

            // Save the progress
            MainMenuData m_Data = MainMenuManager.LoadLevel();
            int index = SceneManager.GetActiveScene().name[6] - '0';
            // Debug.Log("Finished level " + index);
            m_Data.LevelArray[index] = true;
            MainMenuManager.SaveLevel(index);
        }
    }
}
