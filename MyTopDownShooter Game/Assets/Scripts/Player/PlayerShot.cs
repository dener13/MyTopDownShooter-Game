using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShot : MonoBehaviour
{

    [SerializeField]
    private GameObject bulletPrefab;

    public AudioSource audioSource;  // Referência ao componente AudioSource

    [SerializeField]
    private float bulletSpeed;

    private bool fireContinuously;
    private bool fireSingle;
    private float lastFireTime;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private float timeBetweenShots;

    private Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (fireContinuously || fireSingle)
        {
            float timeSinceLastFire = Time.time - lastFireTime;

            if(timeSinceLastFire >= timeBetweenShots)
            {
                FireBullet();

                lastFireTime = Time.time;

                fireSingle = false;
            }
            
        } 
    }

    private void FireBullet()
    {
        anim.SetTrigger("isShoot");
        audioSource.Play(); // Tocar o efeito sonoro do tiro
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.velocity = bulletSpeed * transform.up;

    }

    private void OnFire(InputValue inputValue)
    {
        fireContinuously = inputValue.isPressed;

        if (inputValue.isPressed)
        {
            fireSingle = true;
        }
    }
}
