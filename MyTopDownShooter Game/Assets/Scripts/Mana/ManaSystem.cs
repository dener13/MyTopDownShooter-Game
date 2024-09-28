using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaSystem : MonoBehaviour
{
    public float maxMana = 100;  // Quantidade máxima de mana
    public float currentMana;     // Mana atual
    public float regenRate = 1f;  // Taxa de regeneração de mana por segundo

    void Start()
    {
        // No início do jogo, a mana atual é igual ao máximo
        currentMana = 0;
    }

    void Update()
    {
        // Regenera mana ao longo do tempo, mas não ultrapassa o máximo
        RegenerateMana();
    }

    // Método para gastar mana
    public bool SpendMana(float amount)
    {
        // Verifica se há mana suficiente para gastar
        if (currentMana >= amount)
        {
            currentMana -= amount;
            return true;  // Sucesso
        }
        else
        {
            Debug.Log("Not enough mana!");
            return false;  // Falha
        }
    }

    // Método para regenerar mana
    private void RegenerateMana()
    {
        if (currentMana < maxMana)
        {
            currentMana += regenRate * Time.deltaTime;
            currentMana = Mathf.Min(currentMana, maxMana);  // Garante que não ultrapasse o máximo
        }
    }

    // Método para recuperar mana imediatamente (ex.: usando uma poção)
    public void RestoreMana(float amount)
    {
        currentMana += amount;
        currentMana = Mathf.Min(currentMana, maxMana);
    }
}