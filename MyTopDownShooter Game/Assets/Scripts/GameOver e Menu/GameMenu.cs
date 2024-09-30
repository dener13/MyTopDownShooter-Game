using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameMenu : MonoBehaviour
{

    public TextMeshProUGUI highscoreTxt;

    void Start()
    {
        // Carregar o recorde de pontos salvo e exibir
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highscoreTxt.text = "High Score: " + highScore.ToString();
    }

    public void GoGame()
    {
        SceneManager.LoadScene("Game");
    }

 

  
}
