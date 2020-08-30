using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Point
{
    int X, Y;
    bool active;
}

public class LevelGen : MonoBehaviour
{
    public GameObject cube;
    public int startX, startZ;
    public int endX, endZ;

    public Point[][] arrayPoints;


    /*public int xStart, xEnd;
    public int zStart, zEnd;

    private void Start()
    {
        for (int i = xStart; i <= xEnd; i++)
            for (int j = zStart; j <= zEnd; j++)
                if (i % 5 == 0 && j % 5 == 0 && (i != 0 || j != 0))
                    Instantiate(cube, new Vector3(i, 0, j), new Quaternion());
    }*/
}
