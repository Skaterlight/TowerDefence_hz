using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private EnemyStats enemyStats;
    public int DoDamage => enemyStats.damage;
    private NavMeshAgent agent;
    private int health;
    SpellCaster TargetSetter = new SpellCaster();
    GoldController goldController;

    private Animator animator;
    private bool _TowerCollision = false;

    private void Start()
    {
        goldController = FindAnyObjectByType<GoldController>();

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
        if(other.gameObject.tag == "Spell")
        {
            SpellScript spellScript = other.GetComponent<SpellScript>();
            health -= spellScript.Damage;
            Destroy(other.gameObject);
            if( health <= 0)
            {
                animator.SetTrigger("Dead");
                Destroy(gameObject/*, 0.85f*/);
                goldController.AddGold(enemyStats.Cost);
            }
        }
        if(other.gameObject.tag == "Tower")
        {
            if (TargetSetter.Target == null) TargetSetter.Target = gameObject;
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "MainTower")
        {
            _TowerCollision = true;
        }
    }
    #endregion
}
