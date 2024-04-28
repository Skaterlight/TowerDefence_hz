using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] private Text _text;

    private int _health;

    private void Start()
    {
        _health = 1000;
        _text.text = _health.ToString();
    }

    private void UpdateHealth(GameObject enemy)
    {
        EnemyScript script = enemy.GetComponent<EnemyScript>();
        _health -= script.DoDamage;
        _text.text = _health.ToString();
        Destroy(enemy);
        //if(_health <= 0) Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            UpdateHealth(collision.gameObject);
        }
    }
}
