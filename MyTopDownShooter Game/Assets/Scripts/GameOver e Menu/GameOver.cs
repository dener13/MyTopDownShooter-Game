using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{

    public TextMeshProUGUI highScoreText;  // Referência para o texto onde o recorde será mostrado


    void Start()
    {
        // Carrega o recorde salvo e exibe no texto
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "Highscore: " + highScore.ToString();
    }

    public void GoGameAgain()
    {
        SceneManager.LoadScene("Game");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
