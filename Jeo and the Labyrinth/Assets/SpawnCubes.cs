using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    public int startX, startY;
    public int stopX, stopY;

    public float timeBetweenSpawns;

    public GameObject cube;

    float m_time;
    int i, j;
    bool m_Decrease = false;

    private void Start()
    {
        i = startX;
        j = startY;
    }

    private void Update()
    {
        if (j == stopY)
            return;
        if (i == stopX)
        {
            i = stopX - 1;
            m_Decrease = true;
            j++;
        }
        else if (i == startX)
        {
            i = startX + 1;
            m_Decrease = false;
            j++;
        }
        if (m_time >= timeBetweenSpawns)
        {
            Instantiate(cube, new Vector3(i, 0f, j), new Quaternion());
            if (m_Decrease)
                i--;
            else
                i++;
            m_time = 0f;
        }
        else
            m_time += Time.deltaTime;
    }

}
