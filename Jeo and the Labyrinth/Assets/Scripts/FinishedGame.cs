using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedGame : MonoBehaviour
{
    public GameObject text;

    private void Update()
    {
        MainMenuData m_Data = MainMenuManager.LoadLevel();
        for (int i = 0; i < 6; i++)
        {
            if (m_Data.LevelArray[i] == false)
            {
                // Debug.Log("The level that is unfinished is " + i);
                return;
            }
        }
        text.SetActive(true);
        Destroy(this);
    }
}
