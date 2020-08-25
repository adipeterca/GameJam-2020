using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioButton : MonoBehaviour
{
    public Sprite[] spriteArray;  // 0 - mute, 3 - max volume

    Image m_image;
    int m_state;

    AudioSource m_audioSource;

    private void Start()
    {
        m_image = GetComponent<Image>();
        m_audioSource = GetComponent<AudioSource>();

        MainMenuData m_Data = MainMenuManager.LoadSettings();
        m_state = m_Data.AudioVolume;

        m_image.sprite = spriteArray[m_state];
        AdjustAudio();
    }

    private void AdjustAudio()
    {
        if (m_state == 0)
            m_audioSource.volume = 0f;
        else if (m_state == 1)
            m_audioSource.volume = 0.3f;
        else if (m_state == 2)
            m_audioSource.volume = 0.6f;
        else
            m_audioSource.volume = 1.0f;
    }

    // This gets called whenever the audio button is pressed.
    public void ChangeAudio()
    {
        m_state++;
        if (m_state == spriteArray.Length)
            m_state = 0;
        m_image.sprite = spriteArray[m_state];
        AdjustAudio();

        MainMenuManager.SaveSettings(m_state);
    }
}
