using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public GameObject[] spawners;  // Array de todos os spawners que você deseja ativar/desativar
    public int[] activationThresholds;  // Pontuações para ativar os spawners
    public int[] deactivationThresholds;  // Pontuações para desativar os spawners
    private ScoreManager scoreManager;  // Referência ao sistema de pontuação do jogo

    void Start()
    {
        // Referência ao sistema de pontuação
        scoreManager = FindObjectOfType<ScoreManager>();

        
    }

    void Update()
    {
        // Verifica os spawners a cada frame
        CheckSpawners();
    }

    void CheckSpawners()
    {
        // Itera pelos spawners para ativar e desativar conforme a pontuação
        for (int i = 0; i < spawners.Length; i++)
        {
            // Ativa o spawner se a pontuação atingir o threshold de ativação e se ele ainda não estiver ativo
            if (scoreManager.score >= activationThresholds[i] && !spawners[i].activeSelf)
            {
                spawners[i].SetActive(true);
                Debug.Log("Spawner " + i + " ativado!");
            }

            // Desativa o spawner se a pontuação atingir o threshold de desativação e se ele ainda estiver ativo
            if (scoreManager.score >= deactivationThresholds[i] && spawners[i].activeSelf)
            {
                spawners[i].SetActive(false);
                Debug.Log("Spawner " + i + " desativado!");
            }
        }
    }
}
