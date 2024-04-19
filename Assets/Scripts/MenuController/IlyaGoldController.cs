using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IlyaGoldController : MonoBehaviour
{
    private int gold;
    private bool enemyKilled;
    [SerializeField] private Text goldAmount;
    void Start()
    {
        gold = 0;
        enemyKilled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyKilled == true)
        {
            gold += 25;
            goldAmount.text = gold.ToString();
            enemyKilled = false;
            
        }
    }
}
