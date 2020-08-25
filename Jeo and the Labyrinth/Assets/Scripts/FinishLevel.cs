using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            MainMenuData m_Data = MainMenuManager.LoadLevel();
            int index = 0;
            while (index < 6 && m_Data.LevelArray[index])
                index++;
            if (index < 6)
                MainMenuManager.SaveLevel(index);
        }
    }
}
