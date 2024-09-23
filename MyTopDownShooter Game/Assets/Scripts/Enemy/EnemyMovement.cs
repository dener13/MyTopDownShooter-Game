using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public static EnemyMovement instance;

    private Player player;

    [SerializeField]
    private float speed;

    
    public float life;
    public float maxLife;

    [SerializeField]
    private float rotationSpeed;

    private Rigidbody2D rb;
    private PlayerAwarenessController playerAwarenessController;
    private Vector2 targetDirection;
    private float changeDirectionCooldown;

    public List<DropItem> possibleDrops; // lista de itens que podem ser dropados

    
    private void Awake()
    {
        player = FindObjectOfType<Player>();

        rb = GetComponent<Rigidbody2D>();
        playerAwarenessController = GetComponent<PlayerAwarenessController>();
        targetDirection = transform.up;

        life = maxLife;
    }


    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
        EnemyDeath();
    }


    // Função para determinar quais itens serão dropados
    public void DropLoot()
    {
        foreach (DropItem item in possibleDrops)
        {
            float randomValue = Random.Range(0f, 100f);  // Gera um número aleatório entre 0 e 100
            if (randomValue <= item.dropChance)
            {
                Instantiate(item.itemPrefab, transform.position, Quaternion.identity);  // Dropa o item
            }
        }
    }

    private void EnemyDeath()
    {
        if(life <= 0)
        {
            OnDeath();
        }
    }

    // Chame essa função quando o inimigo morrer
    public void OnDeath()
    {
        DropLoot();
        ScoreManager.instance.AddPoints(ScoreManager.instance.pointsForKill);
        Destroy(this.gameObject);  // Destroi o inimigo
    }


    private void UpdateTargetDirection()
    {
        HandleRandomDirectionChange();
        HandlePlayerTargeting();
        
    }

    private void HandleRandomDirectionChange()
    {
        changeDirectionCooldown -= Time.deltaTime;

        if(changeDirectionCooldown <= 0)
        {
            float angleChange = Random.Range(-90f, 90f);
            Quaternion rotation = Quaternion.AngleAxis(angleChange, transform.forward);
            targetDirection = rotation * targetDirection;

            changeDirectionCooldown = Random.Range(1f, 5f);
        }
    }

    private void HandlePlayerTargeting()
    {
        if (playerAwarenessController.awareOfPlayer)
        {
            targetDirection = playerAwarenessController.directionToPlayer;
        }
    }

    private void RotateTowardsTarget() 
    { 
       

        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        rb.SetRotation(rotation);
    }

    private void SetVelocity()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Bullet":
                life -= player.bulletDamage;
                break;
        }
    }


}
