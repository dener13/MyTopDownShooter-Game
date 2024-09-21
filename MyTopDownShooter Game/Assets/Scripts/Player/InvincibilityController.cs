using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityController : MonoBehaviour
{
    private HealthController healthController;
    public GameObject bloodFxPrefab;
    private SpriteRenderer playerSprite;

    private void Awake()
    {
        healthController = GetComponent<HealthController>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    public void StartInvincibility(float invincibilityDuration)
    {
        StartCoroutine(InvincibilityCoroutine(invincibilityDuration));
    }

    private IEnumerator InvincibilityCoroutine(float invincibilityDuration)
    {
        
        Debug.Log("tomou dano");
        GameObject instanceBloodFx = Instantiate(bloodFxPrefab, transform.position, Quaternion.identity);
        Destroy(instanceBloodFx, 0.5f);
        playerSprite.color = Color.red;
        healthController.IsInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        playerSprite.color = Color.white;
        healthController.IsInvincible = false;
    }
}
