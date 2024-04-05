using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private ScriptObjEnemy enemyStats;
    SpellCaster TargetSetter = new SpellCaster();

    private float health;
    private NavMeshAgent agent;

    private void Start()
    {
        enemyStats.MainTower = GameObject.FindWithTag("MainTower");
        health = enemyStats.Health;

        agent = GetComponent<NavMeshAgent>();
        agent.destination = enemyStats.MainTower.transform.position;
    }

    #region triggers
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Fireball")
        {
            health -= 50;
            Destroy(other.gameObject);
            if( health <= 0) Destroy(gameObject);
        }
        if(other.gameObject.tag == "Tower")
        {
            if (TargetSetter.Target == null) TargetSetter.Target = gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Tower" && TargetSetter.Target != null)
        {
            TargetSetter.Target = null;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if( other.gameObject.tag == "Tower" && TargetSetter.Target == null)
        {
            TargetSetter.Target = gameObject;
        }
    }
    #endregion
}
