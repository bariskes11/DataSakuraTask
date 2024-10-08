using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyDie : IState
{
    private EnemyStateManager enemyStateManager;

    public EnemyDie(EnemyStateManager enemyStateManager)
    {
        this.enemyStateManager = enemyStateManager;
    }


    public void Enter()
    {
        DOVirtual.DelayedCall(1F, () =>
        {
            this.enemyStateManager.gameObject.transform.DOMoveY(-1.5F, .4F)
                .OnComplete(() => { this.enemyStateManager.gameObject.SetActive(false); });
        });
    }

    public void Tick()
    {
    }

    public void FixedTick()
    {
    }

    public void Exit()
    {
    }
}