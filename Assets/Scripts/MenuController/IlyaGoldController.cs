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
    [SerializeField] private LevelFirstUIController levelFirstUIController;
    private Text Tower1Cost;
    private Text Tower2Cost;
    private Text Tower3Cost;
    public GameObject StorePanel;
    private int Tower1Value = 100;
    private int Tower2Value = 200;
    private int Tower3Value = 400;

    void Start()
    {
        gold = 0;
        enemyKilled = false;
        StorePanel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            enemyKilled = true;
        }
        if (enemyKilled == true)
        {
            gold += 25;
            goldAmount.text = gold.ToString() + "$";
            enemyKilled = false;
            //levelFirstUIController.canPlaceTower = true;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            StorePanel.SetActive(true);
        }
        
    }
    public void BuyFirstTower()
    {
        if (gold >= Tower1Value)
        {
            gold -= Tower1Value;
            
        }
        Debug.Log("You Bought a gun");
    }

    public void CloseStorePanel()
    {
        StorePanel.SetActive(false);
    }
}
