using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWalk : EnemyCore, IState
{
    private NavMeshAgent navAgent;
    private PlayerFollowGuide[] targetPosList;

    public EnemyWalk(EnemyStateManager stateManager, EnemyProperties enemyProperties,
        PlayerFollowGuide[] targetPosList, NavMeshAgent navAgent) : base(stateManager, enemyProperties)
    {
        this.navAgent = navAgent;
        this.targetPosList = targetPosList;
    }


    public void Enter()
    {
        Transform target = FindClosestPosition(this.targetPosList);
        if (target is null)
        {
#if UNITY_EDITOR
            Debug.LogError("No Target Found!!");
#endif
            return;
        }

        this.navAgent.SetDestination(target.position);
        this.navAgent.speed = this.properties.MovingSpeed;
        this.navAgent.angularSpeed = this.properties.RotateSpeed;
        this.navAgent.acceleration = this.properties.MovingSpeed;
    }

    public void Tick()
    {
        Transform target = FindClosestPosition(this.targetPosList);
        float distance = Vector3.Distance(this.stateManager.gameObject.transform.position, target.position);
        if (distance <= this.properties.ShootRange)
        {
            this.stateManager.ChangeState(this.stateManager.attackState);
            return;
        }

        this.navAgent.SetDestination(target.position);
    }

    public void FixedTick()
    {
    }

    public void Exit()
    {
        this.navAgent.velocity = Vector3.zero;
        this.navAgent.ResetPath();
        this.navAgent.speed = 0;
        this.navAgent.acceleration = 0;
    }
}