using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public abstract class EnemyBase : StateMachineBase,IEnemy
{
    [SerializeField] protected ParticleSystem hitParticle;
    [SerializeField] protected ParticleSystem dieParticle;
    protected NavMeshAgent navMesh;
    protected PlayerHealthSystem targetPlayer;
    
    public float KillScore { get; set; }
    public float CurrentHealth { get; protected set; }

    public virtual void Shot()
    {
        
    }

    public virtual void TakeDamage(float damage)
    {
        if (this.hitParticle is not null)
        {
            this.hitParticle.Simulate(0,true);
            this.hitParticle.Play();
        }
    }

    public virtual void Die()
    {
        
        if (this.dieParticle is not null)
        {
            this.dieParticle.Simulate(0,true);
            this.dieParticle.Play();
        }
        EventManager.OnEnemyKilled?.Invoke(this);
    }
}
