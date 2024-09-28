using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public GameObject objectToSpawn; // Arraste seu prefab aqui no Inspector


     void Start()
    {
        SpawnObject();
    }

    // Método para instanciar o objeto
    public void SpawnObject()
    {
        Instantiate(objectToSpawn, transform.position, Quaternion.identity);
    }
}
