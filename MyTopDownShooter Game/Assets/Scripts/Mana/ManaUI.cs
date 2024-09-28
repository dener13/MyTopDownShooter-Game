using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaUI : MonoBehaviour
{
    public Image mana;  // Referência ao Slider na UI
    public ManaSystem manaSystem;  // Referência ao sistema de mana

   

    void Update()
    {
        // Atualiza a barra de mana com base na mana atual
        mana.fillAmount = manaSystem.currentMana / manaSystem.maxMana;
    }
}
