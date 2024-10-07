using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DST/EnemyProperties", fileName = "EnemyTypeProperty", order = 1)]
public class EnemyProperties : ScriptableObject
{
    public string EnemyName;
    public float MovingSpeed;
    public float RotateSpeed;
    public float ChaseDistance;
    public float ShootRange;
    public float BulletMoveSpeed;
    public float BulletDamage;
     
    public float TimeOutPerShot;
    public float MaxHealth;
    public int ProjectileIndex;
}