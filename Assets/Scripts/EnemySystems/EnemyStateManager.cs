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
    
    private void Awake()
    {
        if (navMesh is null)
        {
            Debug.LogError("No Navmesh set " + this.gameObject.name, this.gameObject);
            return;
        }

        targetPlayer = FindObjectOfType<PlayerHealthSystem>();
        var playerTargetShotPositions = FindObjectsOfType<PlayerFollowGuide>();

        walkState = new EnemyWalk(this, enemyTypeProperties, playerTargetShotPositions, navMesh);
        attackState = new EnemyAttack(this, enemyTypeProperties, playerTargetShotPositions,
            targetPlayer,this.bulletShotPoint);
        dieState = new EnemyDie();
        this.ChangeState(walkState);
    }


 



}