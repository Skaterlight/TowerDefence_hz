using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerHealthController : MonoBehaviour
{
    
    private int health;
    [SerializeField] private Text _textHealth;
    private bool ilyaTestHealth;
    [SerializeField] private Slider HealthBar;

    void Start()
    {
        health = 1000;
        _textHealth.text = health.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            ilyaTestHealth = true;
        }
        if (ilyaTestHealth)
        {
           ilyaTestHealth = false;
            UpdateHealth();

        }
    }
    private void UpdateHealth()
    {
        health -= 50;
        _textHealth.text = health.ToString();
        HealthBar.value = health;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            health -= 50;
            _textHealth.text = health.ToString();
            HealthBar.value = health;
        }
    }
}
