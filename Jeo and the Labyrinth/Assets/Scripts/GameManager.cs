using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Direction
{
    forward, left, right, backward
}

public class GameManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GameObject pauseMenu;
    public FinishLevel m_FinishLevel;
    static public bool m_ShowingMap = false;

    // The maximum capacity of m_lastPositions
    // const int maxSize = 10;

    //  Direction[] m_lastPositions = new Direction[maxSize];
    // int currentPosition = -1;

    int maxRewinds = 3;

    Animator m_Anim;

    int points = 0;

    // Is the pause menu active?
    bool isActive = false;

    // Position of the last checkpoint
    static Vector3 lastCheckpoint;
    static Vector3 startPoint;

    private void Start()
    {
        m_Anim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        startPoint = lastCheckpoint = playerMovement.transform.position;
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (m_FinishLevel.IsGameFinished())
            return;
        if (isActive)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseMenu.SetActive(false);
                isActive = false;
            }
            else
                return;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseMenu.SetActive(true);
                isActive = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.R) && maxRewinds > 0)
            Rewind();
        else if (Input.GetKeyDown(KeyCode.M))
            ShowMap();
        
    }

    private void ShowMap()
    {
        if (!m_ShowingMap && m_Anim.GetCurrentAnimatorStateInfo(0).IsName("CameraStay"))
        {
            m_Anim.SetBool("ZoomOut", true);
            m_Anim.SetBool("ZoomIn", false);
            m_ShowingMap = true;
        }
        else if (m_ShowingMap && m_Anim.GetCurrentAnimatorStateInfo(0).IsName("CameraStay_2"))
        {
            m_Anim.SetBool("ZoomIn", true);
            m_Anim.SetBool("ZoomOut", false);
            m_ShowingMap = false;
        }
    }

    /*public void AddPosition(Direction dir)
    {
        if (maxSize == currentPosition + 1)
        {
            for (int i = 0; i < currentPosition; i++)
                m_lastPositions[i] = m_lastPositions[i + 1];
            m_lastPositions[currentPosition] = dir;
        }
        else
        {
            m_lastPositions[++currentPosition] = dir;
        }
    }*/

    public bool CanMove()
    {
        return m_Anim.GetCurrentAnimatorStateInfo(0).IsName("CameraStay") &&
                !isActive && !m_FinishLevel.IsGameFinished();
    }

    /*private void RemovePosition()
    {
        if (currentPosition >= 0)
            playerMovement.MovePlayer(GetOpposite(m_lastPositions[currentPosition--]));
    }*/

    private void Rewind()
    {
        playerMovement.transform.position = lastCheckpoint;
        if (lastCheckpoint != startPoint)
            maxRewinds--;
    }

    /*private Direction GetOpposite(Direction dir)
    {
        if (dir == Direction.forward) return Direction.backward;
        if (dir == Direction.left) return Direction.right;
        return Direction.left;
    }*/

    private bool IsAnimationPlaying()
    {
        return m_Anim.GetCurrentAnimatorStateInfo(0).IsName("CameraOverall") || m_Anim.GetCurrentAnimatorStateInfo(0).IsName("CameraFollowPlayer");
    }

    /*public int GetCurrentPosition()
    {
        return currentPosition;
    }*/

    public int GetRemaningRewinds()
    {
        return maxRewinds;
    }

    public void AddPoints(int value)
    {
        points += value;
    }

    public int GetCurrentPoints()
    {
        return points;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        if (SceneManager.GetActiveScene().name == "Level_5")
            SceneManager.LoadScene("MainMenu");
        SceneManager.LoadScene("Level_" + (SceneManager.GetActiveScene().name[6] - '0' + 1));
    }

    public void QuitLevel()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public static void ChangeCheckpointPosition(Vector3 newPos)
    {
        lastCheckpoint = newPos;
    }
}
