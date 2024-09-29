using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    private HealthController healthController;
    private ManaSystem manaSystem;

    public float specialManaCost = 100f;

    public GameObject fireballPrefab;  // Prefab da fireball
    public Transform firePoint;  // Ponto onde a fireball ser� spawnada

    [SerializeField]
    private float speed;

    public int bulletDamage;

    private Animator animator;

    [SerializeField]
    private float rotationSpeed;

    private Rigidbody2D rb;
    private Vector2 movementInput;
    private Vector2 smoothedMovementInput; //armazena o valor suavizado do movimento
    private Vector2 movementInputSmoothVelocity; //Um vetor auxiliar usado pela fun��o SmoothDamp. Ele rastreia a velocidade de suaviza��o interna durante a interpola��o dos valores de movimento.

    private void Awake()
    {
        healthController = FindObjectOfType<HealthController>();
        manaSystem = FindObjectOfType<ManaSystem>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        SetPlayerVelocity();
        RotateInDirectionOfInput();
        SetAnimation();

      
    }


    private void Update()
    {
        if(manaSystem.currentMana >= 100)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                CastFireball();
            }
        }
        else
        {
            
        }
        
    }

    // M�todo para lan�ar uma habilidade
    void CastFireball()
    {
        if (manaSystem.SpendMana(specialManaCost))
        {
            // Instancia a fireball na posi��o do firePoint com a rota��o atual
            Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
            Debug.Log("Fireball cast!");
            manaSystem.currentMana -= 100;
        }
        else
        {
            Debug.Log("Not enough mana to cast Fireball!");
        }
    }

    private void SetAnimation()
    {
        bool isMoving = movementInput != Vector2.zero;
        animator.SetBool("isMoving", isMoving);
    }

    private void SetPlayerVelocity() 
    {
        //valor atual do movimento suavizado, o valor de entrada atual do jogador,
        //Um valor de refer�ncia que � passado por refer�ncia (com ref). Isso permite que o SmoothDamp mantenha internamente a velocidade de transi��o e melhore a suaviza��o ao longo do tempo.
        ////O tempo em segundos que o movimento deve levar para suavizar. Neste caso, ele ir� suavizar em 0,1 segundo.
        smoothedMovementInput = Vector2.SmoothDamp(smoothedMovementInput, movementInput, ref movementInputSmoothVelocity, 0.1f);
        rb.velocity = smoothedMovementInput * speed;
        //O m�todo SmoothDamp suaviza a transi��o entre dois valores de vetor (smoothedMovementInput e movementInput).
        //Isso torna a movimenta��o mais gradual, em vez de mudar de forma abrupta assim que o jogador pressiona uma tecla de movimento.
    }

    private void RotateInDirectionOfInput()
    {
        if(movementInput != Vector2.zero) //se esta se movimentando...
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, smoothedMovementInput);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            rb.MoveRotation(rotation);
        }
    }

    private void OnMove(InputValue inputValue)
    {
        movementInput =  inputValue.Get<Vector2>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "life":
                healthController.AddHealth(25);
                Destroy(other.gameObject);
                break;

            

            case "superpower":
                manaSystem.RestoreMana(100);
                Destroy(other.gameObject);
                break;

            
        }
    }
}
