using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public abstract class EnemyBase : StateMachineBase,IEnemy
{
    
    protected NavMeshAgent navMesh;
    protected PlayerHealthSystem targetPlayer;
    public float KillScore { get; set; }

    public virtual void Shot()
    {
        
    }

    public virtual void TakeDamage(float damage)
    {
        
    }

    public virtual void Die()
    {
        EventManager.OnEnemyKilled?.Invoke(this);
    }
}
