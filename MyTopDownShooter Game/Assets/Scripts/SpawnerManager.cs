using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public GameObject[] spawners;  // Array de todos os spawners que voc� deseja ativar/desativar
    public int[] activationThresholds;  // Pontua��es para ativar os spawners
    public int[] deactivationThresholds;  // Pontua��es para desativar os spawners
    private ScoreManager scoreManager;  // Refer�ncia ao sistema de pontua��o do jogo

    void Start()
    {
        // Refer�ncia ao sistema de pontua��o
        scoreManager = FindObjectOfType<ScoreManager>();

        
    }

    void Update()
    {
        // Verifica os spawners a cada frame
        CheckSpawners();
    }

    void CheckSpawners()
    {
        // Itera pelos spawners para ativar e desativar conforme a pontua��o
        for (int i = 0; i < spawners.Length; i++)
        {
            // Ativa o spawner se a pontua��o atingir o threshold de ativa��o e se ele ainda n�o estiver ativo
            if (scoreManager.score >= activationThresholds[i] && !spawners[i].activeSelf)
            {
                spawners[i].SetActive(true);
                Debug.Log("Spawner " + i + " ativado!");
            }

            // Desativa o spawner se a pontua��o atingir o threshold de desativa��o e se ele ainda estiver ativo
            if (scoreManager.score >= deactivationThresholds[i] && spawners[i].activeSelf)
            {
                spawners[i].SetActive(false);
                Debug.Log("Spawner " + i + " desativado!");
            }
        }
    }
}
