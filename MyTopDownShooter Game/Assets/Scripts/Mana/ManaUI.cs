using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaUI : MonoBehaviour
{
    public Image mana;  // ReferÍncia ao Slider na UI
    public ManaSystem manaSystem;  // ReferÍncia ao sistema de mana

   

    void Update()
    {
        // Atualiza a barra de mana com base na mana atual
        mana.fillAmount = manaSystem.currentMana / manaSystem.maxMana;
    }
}
