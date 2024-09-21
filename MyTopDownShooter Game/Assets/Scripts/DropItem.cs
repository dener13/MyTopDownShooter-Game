using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DropItem : MonoBehaviour
{
   
    public GameObject itemPrefab;  // O prefab do item que será dropado
    [Range(0f, 100f)]
    public float dropChance;       // Chance de drop, em porcentagem (0-100%)
}
