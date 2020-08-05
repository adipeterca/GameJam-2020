using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    forward, left, right, backward
}

public class GameManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    static public bool m_ShowingMap = false;

    // The maximum capacity of m_lastPositions
    const int maxSize = 10;

    Direction[] m_lastPositions = new Direction[maxSize];
    int currentPosition = -1;

    Animator m_Anim;

    private void Start()
    {
        m_Anim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }

    private void Update()
    {  
        if (Input.GetKeyDown(KeyCode.R) && CanMove())
            RemovePosition();
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

    public void AddPosition(Direction dir)
    {
        if (maxSize == currentPosition + 1)
        {
            for (int i = 0; i < currentPosition; i++)
                m_lastPositions[i] = m_lastPositions[i + 1];
            m_lastPositions[currentPosition] = dir;
        }
        else
        {
            // Debug.Log(currentPosition + " current position");
            m_lastPositions[++currentPosition] = dir;
        }
    }

    public bool CanMove()
    {
        return m_Anim.GetCurrentAnimatorStateInfo(0).IsName("CameraStay");
    }

    private void RemovePosition()
    {
        if (currentPosition >= 0)
            playerMovement.MovePlayer(GetOpposite(m_lastPositions[currentPosition--]));
    }

    private Direction GetOpposite(Direction dir)
    {
        if (dir == Direction.forward) return Direction.backward;
        if (dir == Direction.left) return Direction.right;
        return Direction.left;
    }

    private bool IsAnimationPlaying()
    {
        return m_Anim.GetCurrentAnimatorStateInfo(0).IsName("CameraOverall") || m_Anim.GetCurrentAnimatorStateInfo(0).IsName("CameraFollowPlayer");
    }
}
