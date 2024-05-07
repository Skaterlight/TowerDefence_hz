using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] private Text _text;

    public LoseWinController _loseController;
    private int _health;
    private void Start()
    {
        _health = 1000;
        _text.text = _health.ToString();
        _loseController = GetComponent<LoseWinController>();
        if (_loseController == null)
        {
            Debug.Log("Bad");
        }
    }
    private void Update()
    {
        if (_health <= 0) 
        {
            _loseController.Lose();
        }
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
