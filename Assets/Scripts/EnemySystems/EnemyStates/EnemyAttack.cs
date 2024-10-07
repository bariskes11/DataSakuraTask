using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : EnemyCore, IState
{
    private TimeCounter timeOutPerShot;
    private PlayerFollowGuide[] targetPositions;
    private PlayerHealthSystem player;
    private const float distanceOffset = 6F;
    private Transform shotPosition;

    public EnemyAttack(EnemyStateManager stateManager, EnemyProperties enemyProperties,
        PlayerFollowGuide[] targetPositions, PlayerHealthSystem player, Transform shotPosition) : base(stateManager,
        enemyProperties)
    {
        this.Init(stateManager, properties);
        this.targetPositions = targetPositions;
        this.shotPosition = shotPosition;
        this.player = player;
    }

    public void Enter()
    {
        timeOutPerShot = new TimeCounter(this.properties.TimeOutPerShot);
        SetShot();
    }

    private void SetShot()
    {
        // shot bullet
        EnemyProjectile enemyProjectile =
            PoolManager.Instance.SpawnBaseProjectile(properties.ProjectileIndex, shotPosition) as EnemyProjectile;
        enemyProjectile.transform.rotation = shotPosition.rotation;
        enemyProjectile.StartMoving(properties.BulletMoveSpeed, properties.BulletDamage,
            properties.ProjectileIndex);
    }


    public void Tick()
    {
        Transform target = this.FindClosestPosition(this.targetPositions);
        float distance = Vector3.Distance(this.stateManager.gameObject.transform.position, target.position);
        if (distance > this.properties.ShootRange + distanceOffset)
        {
            this.stateManager.ChangeState(this.stateManager.walkState);
        }

        if (timeOutPerShot.IsTickFinished(Time.deltaTime))
        {
            this.SetShot();
            this.stateManager.gameObject.transform.LookAt(player.transform);
            timeOutPerShot.SetTimer(this.properties.TimeOutPerShot);
        }
    }

    public void FixedTick()
    {
    }

    public void Exit()
    {
    }
}