using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : PoolerBase<EnemyStateManager>
{
    [SerializeField] private  EnemyStateManager attackBot;

    private void Start()
    {
        InitPool(attackBot,10,10000,false);
    }
}

