using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public bool m_FollowPlayer = true;

    Vector3 m_Offset;

    private void Start()
    {
        m_Offset = player.position - transform.position;
    }

    private void Update()
    {
        if (m_FollowPlayer)
            transform.position = player.position - m_Offset;
    }
}
