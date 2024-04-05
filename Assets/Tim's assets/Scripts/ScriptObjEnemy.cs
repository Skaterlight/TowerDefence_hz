using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy stats", menuName = "Stats/EnemyStats")]

public class ScriptObjEnemy : ScriptableObject
{
    [HideInInspector] public GameObject MainTower;
    public int Health;
    public int Attack;
    public float AttackSpeed;
}
