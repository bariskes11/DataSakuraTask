using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : EnemyBase
{
    [SerializeField] private EnemyProperties enemyTypeProperties;
    [SerializeField] private Transform bulletShotPoint;
    [SerializeField] private ParticleSystem bulletShotParticle;
    public EnemyWalk walkState { get; private set; }
    public EnemyAttack attackState { get; private set; }
    public EnemyDie dieState { get; private set; }
    private bool isDied = false;
    private void Awake()
    {
        this.navMesh = this.GetComponent<NavMeshAgent>();
        if (navMesh is null)
        {
            Debug.LogError("No Navmesh set " + this.gameObject.name, this.gameObject);
            return;
        }

        targetPlayer = FindObjectOfType<PlayerHealthSystem>();
        var playerTargetShotPositions = FindObjectsOfType<PlayerFollowGuide>();
        this.CurrentHealth = enemyTypeProperties.MaxHealth;
        walkState = new EnemyWalk(this, enemyTypeProperties, playerTargetShotPositions, navMesh);
        attackState = new EnemyAttack(this, enemyTypeProperties, playerTargetShotPositions,
            targetPlayer,this.bulletShotPoint,this.bulletShotParticle);
        dieState = new EnemyDie(this);
        this.KillScore = this.enemyTypeProperties.KillScore;
        this.ChangeState(walkState);
    }

    private void OnEnable()
    {
        isDied = false;
        this.CurrentHealth = enemyTypeProperties.MaxHealth;
        // to reset state when recalled from pool
        this.ChangeState(walkState);
    }


    public override void TakeDamage(float damage)
    {
        if(isDied) return;
        base.TakeDamage(damage);
        this.CurrentHealth -= damage;
        #if UNITY_EDITOR
        Debug.Log($"Current health{this.CurrentHealth}",this);
        #endif
        if (CurrentHealth <= 0F)
        {
            this.Die();
        }

    }

    public override void Die()
    {
        
        base.Die();
        this.ChangeState(dieState);
        isDied = true;
    }
}