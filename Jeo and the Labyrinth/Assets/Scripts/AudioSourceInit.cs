using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceInit : MonoBehaviour
{
    private AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        MainMenuData m_Data = MainMenuManager.LoadSettings();
        sound = GetComponent<AudioSource>();
        sound.volume = m_Data.AudioVolume / 3.0f;
        Debug.Log(sound.volume);
    }
}
