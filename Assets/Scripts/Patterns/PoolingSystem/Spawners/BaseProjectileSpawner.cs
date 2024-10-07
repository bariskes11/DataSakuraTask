using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BaseProjectileSpawner : PoolerBase<BaseProjectile>
{
    [SerializeField] private  BaseProjectile baseProjectile;

    private void Start()
    {
        InitPool(baseProjectile,10,10000,false);
    }
}
