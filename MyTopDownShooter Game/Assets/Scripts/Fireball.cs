using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float lifetime;  // Dura��o da fireball antes de desaparecer
    public int fireBallDamage;  // Dano causado pela fireball

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    
}
