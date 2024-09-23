using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;
    public int money = 0;
    public TextMeshProUGUI moneyTxt; // Campo opcional para exibir o money na tela

    

    private void Awake()
    {
        // Garante que existe apenas uma instância do moneyManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddMoney(int moneyPts)
    {
        money += moneyPts;
        UpdateMoneyText();
    }

    private void UpdateMoneyText()
    {
        if (moneyTxt != null)
        {
            moneyTxt.text = "Cash: " + money;
        }
    }

}
