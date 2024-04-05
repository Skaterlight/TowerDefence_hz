using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTowerScript : MonoBehaviour
{
    [SerializeField] private ScriptObjEnemy enemyStats;
    private int CollisionCount = 0;
    private int health = 1000;

    private void Start()
    {
        StartCoroutine(WaitOnCollision());
    }

    private IEnumerator WaitOnCollision()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemyStats.AttackSpeed);
            health -= CollisionCount * enemyStats.Attack;
            if(health <= 0) Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) CollisionCount++;
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy")) CollisionCount--;
    }
}
