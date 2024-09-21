using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject hitFx;

    private void Start()
    {
        Destroy(gameObject, 5f); // Destroi o bullet ap�s 5 segundos
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Enemy":
                GameObject instance = Instantiate(hitFx, other.transform.position, Quaternion.identity);
                Destroy(instance, 0.5f);
                Destroy(this.gameObject);
                ScoreManager.instance.AddPoints(ScoreManager.instance.pointsForKill);
                break;
        }
    }
}
