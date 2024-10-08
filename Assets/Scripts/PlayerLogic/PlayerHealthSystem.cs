using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerController))]
public class PlayerHealthSystem : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private PlayerHit playerHit;

    private PlayerProperties playerProperties;
    private PlayerController playerController;
    private float currentHealth = 0F;
    
    private void Awake()
    {
        this.playerController = this.GetComponent<PlayerController>();
        if (playerController is null)
        {
            #if UNITY_EDITOR
            Debug.LogError("Player Controlelr Not found");
            return;
#endif
        }
        this.playerProperties = this.playerController.GetPlayerProperties();
        this.currentHealth = this.playerProperties.MaxHealth;
        this.healthSlider.minValue = 0F;
        this.healthSlider.maxValue =this.playerProperties.MaxHealth;
        this.healthSlider.value = currentHealth;
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
            if(!this.playerController.IsControlEnabled) return; 
            this.playerHit.Onhit();
            this.healthSlider.value = this.currentHealth;
            if (currentHealth <= 0)
            {
                EventManager.OnGameOver?.Invoke();
                // player dead
                this.playerController.DisableControls();
                this.playerController.PlayerDied();
                
            }

            
            
        }
    }
}