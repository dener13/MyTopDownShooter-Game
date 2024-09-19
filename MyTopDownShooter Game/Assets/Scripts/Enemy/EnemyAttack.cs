using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [SerializeField]
    private float damageAmount;

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            var healthController = other.gameObject.GetComponent<HealthController>();

            healthController.TakeDamage(damageAmount); 
        }
    }
}
