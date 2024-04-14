using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private EnemyStats enemyStats;
    public int DoDamage => enemyStats.damage;
    public float AttackTime => enemyStats.attackSpeed;
    private NavMeshAgent agent;
    private int health;
    SpellCaster TargetSetter = new SpellCaster();
    SpawnTowerFull spawnTowerFull = new SpawnTowerFull();

    private Animator animator;
    private bool _TowerCollision = false;

    private void Start()
    {
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
                spawnTowerFull.AddGold(50);
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
        }
    }
}
