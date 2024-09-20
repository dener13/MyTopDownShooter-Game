using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void Start()
    {
        Destroy(gameObject, 5f); // Destroi o bullet após 5 segundos
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
                break;
        }
    }
}
