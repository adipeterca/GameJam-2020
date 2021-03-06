﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float movementTime = 4f; // Time between each read of input
    public float rayLength;

    public GameManager gameManager;

    bool m_Forward, m_Left, m_Right, m_Backward;

    
    float m_Time;
    Rigidbody m_Rigidbody;
    

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Time = 0f;
    }

    private void Update()
    {
        m_Forward = Input.GetKey(KeyCode.W);
        m_Left = Input.GetKey(KeyCode.A);
        m_Right = Input.GetKey(KeyCode.D);
        m_Backward = Input.GetKey(KeyCode.S);

        if (m_Forward && CanMove(Vector3.forward) && m_Time <= 0f && gameManager.CanMove())
        {
            // gameManager.AddPosition(Direction.forward);
            MovePlayer(Direction.forward);
            m_Time = movementTime;
        }
        else if (m_Left && CanMove(Vector3.left) && m_Time <= 0f && gameManager.CanMove())
        {
            // gameManager.AddPosition(Direction.left);
            MovePlayer(Direction.left);
            m_Time = movementTime;
        }
        else if (m_Right && CanMove(Vector3.right) && m_Time <= 0f && gameManager.CanMove())
        {
            // gameManager.AddPosition(Direction.right);
            MovePlayer(Direction.right);
            m_Time = movementTime;
        }
        else if (m_Backward && CanMove(Vector3.back) && m_Time <= 0f && gameManager.CanMove())
        {
            MovePlayer(Direction.backward);
            m_Time = movementTime;
        }
        m_Time -= Time.deltaTime;
    }

    private bool CanMove(Vector3 dir)
    {
        int layerMask = 1 << 9;
        bool info = !Physics.Raycast(transform.position, dir, rayLength, layerMask);
        // Debug.DrawRay(transform.position, dir * rayLength, Color.blue, 2);
        return info;  
    }

    public void MovePlayer(Direction dir)
    {
        if (dir == Direction.forward)
            m_Rigidbody.AddForce(new Vector3(0, 0, 1) * movementSpeed);
        else if (dir == Direction.left)
            m_Rigidbody.AddForce(new Vector3(-1, 0, 0) * movementSpeed);
        else if (dir == Direction.right)
            m_Rigidbody.AddForce(new Vector3(1, 0, 0) * movementSpeed);
        else
            m_Rigidbody.AddForce(new Vector3(0, 0, -1) * movementSpeed);
    }

    public void MovePlayerWithSpeed(Direction dir, float speed)
    {
        if (dir == Direction.forward)
            m_Rigidbody.AddForce(new Vector3(0, 0, 1) * speed);
        else if (dir == Direction.left)
            m_Rigidbody.AddForce(new Vector3(-1, 0, 0) * speed);
        else if (dir == Direction.right)
            m_Rigidbody.AddForce(new Vector3(1, 0, 0) * speed);
        else
            m_Rigidbody.AddForce(new Vector3(0, 0, -1) * speed);
    }

}
