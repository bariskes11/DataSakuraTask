using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    public float KillScore { get; set; }
    void Shot();
    void TakeDamage(float damage);
    void Die();
}