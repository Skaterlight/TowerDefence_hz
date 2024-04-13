using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CastleScript : MonoBehaviour
{
    [SerializeField] private EnemyStats goblinStats;
    [SerializeField] private Text towerHealthText;

    private int _goblinCount = 0;
    private bool CorRunning;

    private int _health = 1000;

    private void Update()
    {
        towerHealthText.text = _health.ToString();
        if(_health <= 0)
        {
            Destroy(gameObject);
        }
        if (CorRunning && _goblinCount == 0) StopCoroutine("TakeDamage");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyGoblin"))
        {
            if(!CorRunning)StartCoroutine("TakeDamage");
            _goblinCount++;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("EnemyGoblin")) _goblinCount--;
    }

    IEnumerator TakeDamage()
    {
        CorRunning = true;
        yield return new WaitForSeconds(goblinStats.attackSpeed);
        _health -= goblinStats.damage * _goblinCount;
        CorRunning = false;
    }
}
