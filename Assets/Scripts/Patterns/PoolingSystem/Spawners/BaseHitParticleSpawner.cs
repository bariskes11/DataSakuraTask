using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHitParticleSpawner : PoolerBase<BaseHitParticle>
{
    [SerializeField] private BaseHitParticle baseHitParticle;

    private void Start()
    {
        InitPool(baseHitParticle,10,10000,false);
    }
}
