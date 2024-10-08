using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : BaseProjectile
{
    private bool isTriggered = false;
    private void Awake()
    {
        this.bulletType = CommonVariables.BulletTypes.PlayerBullet;
    }

    private void OnEnable()
    {
        this.isTriggered = false;
    }


    void OnTriggerEnter(Collider other)
    {
        if(this.isTriggered) return;
        
        if (other.TryGetComponent(out IEnemy hitEnemy))
        {
            this.isTriggered = true;
            hitEnemy.TakeDamage(bulletDamage);
        }
    }
}
