using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private EnemyStats enemyStats;
    public int DoDamage => enemyStats.damage;
    private NavMeshAgent agent;
    private int health;
    SpellCaster TargetSetter = new SpellCaster();
    GoldController goldController;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.Play();
        goldController = FindAnyObjectByType<GoldController>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = enemyStats.WalkSpeed;
        agent.destination = GameObject.FindWithTag("MainTower").transform.position;
        health = enemyStats.health;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Spell")
        {
            SpellScript spellScript = other.GetComponent<SpellScript>();
            health -= spellScript.Damage;
            Destroy(other.gameObject);
            CheckHealth();
        }
        if(other.gameObject.tag == "Tower")
        {
            if (TargetSetter.Target == null) TargetSetter.Target = gameObject;
        }
    }

    private void CheckHealth()
    {
        if (health <= 0)
        {
            audioSource.Play();
            Destroy(gameObject);
            goldController.AddGold(enemyStats.Cost);
        }
    }

    #region hide
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
