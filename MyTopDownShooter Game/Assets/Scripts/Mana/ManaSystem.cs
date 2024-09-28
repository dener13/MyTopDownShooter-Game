using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaSystem : MonoBehaviour
{
    public float maxMana = 100;  // Quantidade m�xima de mana
    public float currentMana;     // Mana atual
    public float regenRate = 1f;  // Taxa de regenera��o de mana por segundo

    void Start()
    {
        // No in�cio do jogo, a mana atual � igual ao m�ximo
        currentMana = 0;
    }

    void Update()
    {
        // Regenera mana ao longo do tempo, mas n�o ultrapassa o m�ximo
        RegenerateMana();
    }

    // M�todo para gastar mana
    public bool SpendMana(float amount)
    {
        // Verifica se h� mana suficiente para gastar
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

    // M�todo para regenerar mana
    private void RegenerateMana()
    {
        if (currentMana < maxMana)
        {
            currentMana += regenRate * Time.deltaTime;
            currentMana = Mathf.Min(currentMana, maxMana);  // Garante que n�o ultrapasse o m�ximo
        }
    }

    // M�todo para recuperar mana imediatamente (ex.: usando uma po��o)
    public void RestoreMana(float amount)
    {
        currentMana += amount;
        currentMana = Mathf.Min(currentMana, maxMana);
    }
}