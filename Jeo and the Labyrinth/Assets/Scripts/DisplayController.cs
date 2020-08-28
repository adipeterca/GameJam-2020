using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayController : MonoBehaviour
{
    public TextMeshProUGUI rewindText;
    public TextMeshProUGUI scoreText;
    public GameManager gameManager;

    private void Update()
    {
        rewindText.text = "Rewinds: " + (gameManager.GetRemaningRewinds()).ToString();
        scoreText.text = "Score: " + gameManager.GetCurrentPoints().ToString();
    }
}
