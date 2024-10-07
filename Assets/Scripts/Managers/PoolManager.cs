using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : SingletonCreator<PoolManager>
{
    [SerializeField] private List<BaseProjectileSpawner> baseProjectileSpawner;
    [SerializeField] private List<BaseHitParticleSpawner> hitParticleSpawners;

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

    public void ReturnBaseProjectile(BaseProjectile projectile, int targetIndex)
    {
        baseProjectileSpawner[targetIndex].Release(projectile);
    }

    public BaseHitParticle SpawnHitProjectileParticle(  int particleIndex,Transform spawnPosition)
    {
        BaseHitParticle baseHitParticle = hitParticleSpawners[particleIndex].Get();
        baseHitParticle.gameObject.SetActive(true);
        baseHitParticle.transform.position = spawnPosition.position;
        return baseHitParticle;
    }
}