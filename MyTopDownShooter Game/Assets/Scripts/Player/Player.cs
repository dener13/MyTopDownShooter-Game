using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;


    private Animator animator;

    [SerializeField]
    private float rotationSpeed;

    private Rigidbody2D rb;
    private Vector2 movementInput;
    private Vector2 smoothedMovementInput; //armazena o valor suavizado do movimento
    private Vector2 movementInputSmoothVelocity; //Um vetor auxiliar usado pela fun��o SmoothDamp. Ele rastreia a velocidade de suaviza��o interna durante a interpola��o dos valores de movimento.

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        SetPlayerVelocity();
        RotateInDirectionOfInput();
        SetAnimation();
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
}
