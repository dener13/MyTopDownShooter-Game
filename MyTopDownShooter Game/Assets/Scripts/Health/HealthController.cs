using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    public static HealthController instance;
    private ScoreManager scoreManager;


    public AudioSource deadSound;

    [SerializeField]
    public float currentHealth;

    [SerializeField]
    private float maximumHealth;

    public float RemainingHealthPercentage
    {
        get
        {
            return currentHealth / maximumHealth;
        }
    }

    public bool IsInvincible { get; set; }

    public UnityEvent OnDied;
    public UnityEvent OnDamaged;
    public UnityEvent OnHealthChanged;


    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void TakeDamage(float damageAmount)
    {
        
        if(currentHealth == 0)
        {
            return;
        }

        if (IsInvincible)
        {
            return; 
        }

        currentHealth -= damageAmount;

        OnHealthChanged.Invoke();

        if(currentHealth < 0)
        {
            currentHealth = 0;
        }

        if(currentHealth == 0)
        {
            OnDied.Invoke();
            deadSound.Play();
            StartCoroutine("TransitionToGameOver");

            // Verifica se o jogador bateu o recorde
            int highScore = PlayerPrefs.GetInt("HighScore", 0);  // Carrega o recorde salvo (0 se não houver)

            if (scoreManager.score > highScore)
            {
                // Se a pontuação atual for maior, salva o novo recorde
                PlayerPrefs.SetInt("HighScore", scoreManager.score);
                Debug.Log("Novo recorde: " + scoreManager.score);
            }
        }
        else
        {
            OnDamaged.Invoke();
            
        }
    }

    public void AddHealth(float amountToAdd)
    {
        if(currentHealth == maximumHealth)
        {
            return;
        }

        currentHealth += amountToAdd;

        OnHealthChanged.Invoke();

        if(currentHealth > maximumHealth)
        {
            currentHealth = maximumHealth;
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    IEnumerator TransitionToGameOver()
    {
        yield return new WaitForSeconds(3f);
        GameOver();
    }
}
