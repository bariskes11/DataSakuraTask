using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : SingletonCreator<PoolManager>
{
    [SerializeField] private List<BaseProjectileSpawner> baseProjectileSpawner;
    [SerializeField] private List<EnemySpawner> enemySpawners;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

   

    public BaseProjectile SpawnBaseProjectile(int targetIndex,Transform spawnPosition)
    {
        BaseProjectile baseProjectile = baseProjectileSpawner[targetIndex].Get();
        baseProjectile.gameObject.SetActive(true);
        baseProjectile.transform.position = spawnPosition.position;
        return baseProjectile;
    }

    public EnemyStateManager SpawnEnemy(int targetIndex, Transform spawnPosition)
    {
        EnemyStateManager enemy = enemySpawners[targetIndex].Get();
        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPosition.position;
        return enemy;
    }

  
}