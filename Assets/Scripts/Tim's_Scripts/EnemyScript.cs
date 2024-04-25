using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private EnemyStats enemyStats;
    public int DoDamage => enemyStats.damage;
    private NavMeshAgent agent;
    private int health;
    private int repeatPoison = 0;
    SpellCaster TargetSetter = new SpellCaster();
    GoldController goldController;

    private void Start()
    {
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
            if (spellScript.Lasting == 0)
            {
                health -= spellScript.Damage;
                Destroy(other.gameObject);
                CheckHealth();
            }
            if(spellScript.Lasting != 0) 
            {
                Destroy(other.gameObject);
                StartCoroutine(TakePoison(spellScript.Damage, spellScript.Lasting));
            }
        }
        if(other.gameObject.tag == "Tower")
        {
            if (TargetSetter.Target == null) TargetSetter.Target = gameObject;
        }
    }

    IEnumerator TakePoison(int Damage, int ToRepeat)
    {
        health -= Damage;
        CheckHealth();
        repeatPoison++;
        if(repeatPoison == ToRepeat)
        {
            StopCoroutine(TakePoison(Damage, ToRepeat));
            repeatPoison = 0;
        }
        yield return new WaitForSeconds(1);
    }

    private void CheckHealth()
    {
        if (health <= 0)
        {
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
