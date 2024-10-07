using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DST/PlayerProperties", fileName = "PlayerProperties", order = 1)]
public class PlayerProperties : ScriptableObject
{
    public float MovingSpeed;
    public float RotateSpeed;
    public float BulletSpeed;
    public float BulletDamage;
    public float TimeOutPerShot;
    public float MaxHealth;
    public int ProjectileIndex;
}