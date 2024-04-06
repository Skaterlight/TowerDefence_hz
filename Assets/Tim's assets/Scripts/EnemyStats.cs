using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Stats/EnemyStats", order = 1)]

public class EnemyStats : ScriptableObject
{
    public GameObject _enemyPrefab;
    public int health;
    public int damage;
    public float attackSpeed;
}
