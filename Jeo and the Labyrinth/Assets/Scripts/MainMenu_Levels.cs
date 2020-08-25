using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu_Levels : MonoBehaviour
{
    public GameObject[] menuButtons;
    public GameObject[] levelButtons;

    private void Awake()
    {
        // This initializes the menu.
        ShowMenuButtons(true);
    }

    public void DisplayLevels()
    {
        MainMenuData m_Data = MainMenuManager.LoadLevel();

        // We always show the tutorial to be selectable.
        levelButtons[0].GetComponent<Button>().interactable = true;

        for (int i = 1; i < m_Data.LevelArray.Length; i++)
            levelButtons[i].GetComponent<Button>().interactable = m_Data.LevelArray[i];
        ShowMenuButtons(false);
    }

    public void BackButton()
    {
        ShowMenuButtons(true);
    }

    private void ShowMenuButtons(bool hide)
    {
        for (int i = 0; i < menuButtons.Length; i++)
            menuButtons[i].SetActive(hide);
        for (int i = 0; i < levelButtons.Length; i++)
            levelButtons[i].SetActive(!hide);
    }
}
