using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseProjectile : MonoBehaviour
{
    [SerializeField] protected float bulletMoveSpeed;
    [SerializeField] protected float bulletDamage;
    [SerializeField] protected int projectileIndex;
    protected Vector3 shootPoint = Vector3.zero;
    protected bool isStartedMoving=false;
    private void Start()
    {
    }

    public virtual void StartMoving()
    {
        this.isStartedMoving = true;

    }

    protected virtual void Update()
    {
        if(!isStartedMoving)
            return;
        
        this.transform.Translate(Vector3.forward * bulletMoveSpeed * Time.deltaTime);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        // if (other.TryGetComponent<EnemyBase>(out var hitEnemy))
        // {
        //     hitEnemy.TakeDamage(bulletDamage);
        // }

        ReturnToPool();
    }

    protected virtual void ReturnToPool()
    {
        PoolManager.Instance.ReturnBaseProjectile(this, projectileIndex);
    }
}