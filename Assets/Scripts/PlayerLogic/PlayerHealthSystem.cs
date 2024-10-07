using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerController))]
public class PlayerHealthSystem : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private PlayerHit playerHit;

    private PlayerProperties playerProperties;
    private float currentHealth = 0F;

    private void Awake()
    {
        this.playerProperties = this.GetComponent<PlayerController>().GetPlayerProperties();
        this.currentHealth = this.playerProperties.MaxHealth;
        this.healthSlider.minValue = this.playerProperties.MaxHealth;
        this.healthSlider.maxValue = 0F;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyProjectile>(out var enemyProjectile))
        {
#if UNITY_EDITOR
            Debug.Log("Player Hit", enemyProjectile.gameObject);
#endif
            this.currentHealth -= enemyProjectile.GetDamage();
            enemyProjectile.gameObject.SetActive(false);
            this.playerHit.Onhit();
            this.healthSlider.value = this.currentHealth;
            if (currentHealth <= 0)
            {
                // player dead
            }

            
            
        }
    }
}