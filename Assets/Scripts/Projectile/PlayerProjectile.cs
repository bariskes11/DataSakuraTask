using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : BaseProjectile
{
    
    private void Awake()
    {
        this.bulletType = CommonVariables.BulletTypes.PlayerBullet;
    }
    

     void OnTriggerEnter(Collider other)
    {
        
        if (other.TryGetComponent(out IEnemy hitEnemy))
        {
            hitEnemy.TakeDamage(bulletDamage);
        }
    }
}
