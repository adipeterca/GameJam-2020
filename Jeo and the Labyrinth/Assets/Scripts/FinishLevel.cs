using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            MainMenuData m_Data = MainMenuManager.LoadLevel();
            int index = SceneManager.GetActiveScene().name[6] - '0';
            Debug.Log("Finished level " + index);
            m_Data.LevelArray[index] = true;
            
            MainMenuManager.SaveLevel(index);
        }
    }
}
