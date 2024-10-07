using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public abstract class BaseProjectile : MonoBehaviour
{
    protected float bulletMoveSpeed;
    protected float bulletDamage;
    protected int projectileIndex;
    protected Vector3 shootPoint = Vector3.zero;
    protected bool isStartedMoving = false;
    protected CommonVariables.BulletTypes bulletType;

    private void Start()
    {
    }


    public virtual void StartMoving(float moveSpeed,float damage,int projectileIndex)
    {
        this.bulletMoveSpeed = moveSpeed;
        this.bulletDamage = damage;
        this.projectileIndex = projectileIndex;
        this.isStartedMoving = true;
    }


    protected virtual void Update()
    {
        if (!isStartedMoving)
            return;

        this.transform.Translate(Vector3.forward * bulletMoveSpeed * Time.deltaTime);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        ReturnToPool();
    }

    protected virtual void ReturnToPool()
    {
        PoolManager.Instance.ReturnBaseProjectile(this, projectileIndex);
    }
}