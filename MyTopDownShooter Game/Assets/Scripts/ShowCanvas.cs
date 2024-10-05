using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCanvas : MonoBehaviour
{
    public GameObject canvasToToggle;  // O Canvas que ser� exibido e ocultado

    // Fun��o para mostrar ou esconder o Canvas
    public void Toggle()
    {
        bool isActive = canvasToToggle.activeSelf;
        canvasToToggle.SetActive(!isActive);  // Alterna o estado ativo/inativo
    }
    
    // Fun��o para fechar o Canvas
    public void CloseCanvas()
    {
        canvasToToggle.SetActive(false);  // Desativa o Canvas
    }
}
