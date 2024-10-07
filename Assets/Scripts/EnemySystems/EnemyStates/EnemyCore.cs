using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyCore  
{
    protected EnemyStateManager stateManager;
    protected EnemyProperties properties;

    protected EnemyCore(EnemyStateManager enemyStateManager,EnemyProperties properties)
    {
        this.Init(enemyStateManager,properties);
    }

    protected  void Init(EnemyStateManager enemyStateManager,  EnemyProperties properties)
    {
       
        this.stateManager = enemyStateManager;
        this.properties = properties;
    }
    protected Transform FindClosestPosition(PlayerFollowGuide[] targetPositions)
    {
        float minDis = Mathf.Infinity;
        Transform closest = null;
        foreach (PlayerFollowGuide targetPos in targetPositions)
        {
            float distance = Vector3.Distance(targetPos.transform.position,
                this.stateManager.gameObject.transform.position);
            if (distance < minDis)
            {
                closest = targetPos.transform;
                minDis = distance;
            }
        }

        return closest;
    }
    
}
