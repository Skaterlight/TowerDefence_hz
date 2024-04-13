using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private EnemyStats enemyStats;
    private NavMeshAgent agent;
    private int health;
    SpellCaster TargetSetter = new SpellCaster();

    private GameObject _mainTower;
    private int _mainTowerHealth = 1000;
    [SerializeField] private Text _mainTowerText;

    private Animator animator;
    private bool _TowerCollision = false;

    private void Start()
    {
        _mainTower = GameObject.FindWithTag("MainTower");

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
            InvokeRepeating("DamageTower", enemyStats.attackSpeed, enemyStats.attackSpeed);
        }
    }

    private void DamageTower()
    {
        _mainTowerHealth -= enemyStats.damage;
        _mainTowerText.text = _mainTowerHealth.ToString() + "hp";
        if (_mainTowerHealth <= 0) Destroy(_mainTower);
    }
}
