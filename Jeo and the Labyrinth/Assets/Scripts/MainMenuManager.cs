using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[System.Serializable]
public class MainMenuData
{
    public int AudioVolume;
    public bool[] LevelArray;   // 0 - tutorial, dupa restul. 
    
    public MainMenuData()
    {
        // This just initializes the data.
        AudioVolume = 2;
        LevelArray = new bool[6];
        for (int i = 0; i < 6; i++)
            LevelArray[i] = false;
    }

}

public class MainMenuManager : MonoBehaviour
{
    public bool reset;
    private void Start()
    {
        if (!File.Exists(Application.persistentDataPath + "/level.save") || reset)
            SaveLevel(-1);
        if (!File.Exists(Application.persistentDataPath + "/settings.save"))
            SaveSettings(2);
    }

    public void PlayButton()
    {
        // The level with the index 0 is the tutorial.
        int levelToLoad = 0;
        MainMenuData m_Data = LoadLevel();

        // We search for the first unfinished level.
        while (levelToLoad < 6 && m_Data.LevelArray[levelToLoad])
            levelToLoad++;

        string levelString = "Level_" + levelToLoad.ToString();

        SceneManager.LoadScene(levelString);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public static void SaveLevel(int level)
    {
        BinaryFormatter binary = new BinaryFormatter();

        string path = Application.persistentDataPath + "/level.save";
        FileStream stream = new FileStream(path, FileMode.Create);
        

        MainMenuData m_Data = new MainMenuData();
        for (int i = 0; i <= level; i++)
            m_Data.LevelArray[i] = true;

        binary.Serialize(stream, m_Data);
        stream.Close();
    }

    public static void SaveSettings(int audio)
    {
        BinaryFormatter binary = new BinaryFormatter();

        string path = Application.persistentDataPath + "/settings.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        MainMenuData m_Data = new MainMenuData();
        m_Data.AudioVolume = audio;

        binary.Serialize(stream, m_Data);
        stream.Close();
    }

    public static MainMenuData LoadLevel()
    {
        BinaryFormatter binary = new BinaryFormatter();

        string path = Application.persistentDataPath + "/level.save";
        if (!File.Exists(path))
        {
            Debug.LogError("Save file not found at " + path);
            return null;
        }
        FileStream stream = new FileStream(path, FileMode.Open);

        MainMenuData m_Data = binary.Deserialize(stream) as MainMenuData;
        stream.Close();
        return m_Data;
    }

    public static MainMenuData LoadSettings()
    {
        BinaryFormatter binary = new BinaryFormatter();

        string path = Application.persistentDataPath + "/settings.save";
        if (!File.Exists(path))
        {
            Debug.LogError("Save file not found at " + path);
            return null;
        }
        FileStream stream = new FileStream(path, FileMode.Open);

        MainMenuData m_Data = binary.Deserialize(stream) as MainMenuData;
        stream.Close();
        return m_Data;
    }
}
