using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] private Text _text;

    LoseWinController _loseController;


    private int _health;
    private void Start()
    {
        _loseController = FindAnyObjectByType<LoseWinController>();

        _health = 1000;
        _text.text = _health.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<EnemyScript>(out EnemyScript enemy))
        {
            EnemyScript script = enemy.GetComponent<EnemyScript>();
            _health -= script.DoDamage;
            _text.text = _health.ToString();
            Destroy(enemy.gameObject);

            if(_health <= 0)
            {
                _health = 0;
                _loseController.Lose();
            }
        }
    }
}
