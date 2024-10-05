using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCanvas : MonoBehaviour
{
    public GameObject canvasToToggle;  // O Canvas que será exibido e ocultado

    // Função para mostrar ou esconder o Canvas
    public void Toggle()
    {
        bool isActive = canvasToToggle.activeSelf;
        canvasToToggle.SetActive(!isActive);  // Alterna o estado ativo/inativo
    }
    
    // Função para fechar o Canvas
    public void CloseCanvas()
    {
        canvasToToggle.SetActive(false);  // Desativa o Canvas
    }
}
