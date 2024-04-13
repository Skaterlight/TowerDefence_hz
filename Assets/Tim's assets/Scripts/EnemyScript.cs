using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private EnemyStats enemyStats;
    private NavMeshAgent agent;
    private int health;
    SpellCaster TargetSetter = new SpellCaster();

    GameObject mainTower;
    CastleScript castleScript;

    private Animator animator;
    private bool _TowerCollision = false;

    private void Start()
    {
        /*mainTower = GameObject.FindWithTag("MainTower");
        castleScript = mainTower.GetComponent<CastleScript>();*/

        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = enemyStats.WalkSpeed;
        agent.destination = GameObject.FindWithTag("MainTower").transform.position;
        health = enemyStats.health;
    }

    private void Update()
    {
        animator.SetBool("TowerCollision", _TowerCollision);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Fireball")
        {
            health -= 50;
            Destroy(other.gameObject);
            if( health <= 0)
            {
                animator.SetTrigger("Dead");
                Destroy(gameObject, 0.85f);
            }
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "MainTower")
        {
            _TowerCollision = true;
            //StartCoroutine("DamageTower");
        }
    }

    /*IEnumerator DamageTower()
    {
        yield return new WaitForSeconds(0.7f);
        castleScript.Health = PlayerPrefs.GetInt("MainTowerHealth");
        castleScript.Health -= enemyStats.damage;
        PlayerPrefs.SetInt("MainTowerHealth", castleScript.Health);
        yield return new WaitForSeconds(0.533f);
    }*/
}
