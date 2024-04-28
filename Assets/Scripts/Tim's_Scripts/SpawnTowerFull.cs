using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SpawnTowerFull : MonoBehaviour
{
    GoldController goldController;

    //[SerializeField] private Text TextMoney;
    //private int Money = 500;
    private int BigTower = 2000;
    private int SmallTower = 500;

    RaycastHit hit;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject _Smallprefab;
    private Camera _mainCamera;
    private bool PlaceBigTower = false;
    private bool placesmalltower = false;

    void Start()
    {
        goldController = FindAnyObjectByType<GoldController>();

        _mainCamera = Camera.main;

        /* error here
        Button button = GameObject.Find("ButtonBT").GetComponent<Button>();
        button.onClick.AddListener(placebigtower);

        Button button2 = GameObject.Find("ButtonMT").GetComponent<Button>();
        button2.onClick.AddListener(PlaceSmalltower);
        */
    }

    private void Update()
    {
        OnButtonDown();
    }
    private void placebigtower()
    {
        PlaceBigTower = true;
    }
    private void PlaceSmalltower()
    {
        placesmalltower = true;

    }

    public void OnButtonDown()
    {

        if (PlaceBigTower && Input.GetMouseButtonDown(0))
        {
            if (goldController.MyGold >= BigTower)
            {
                Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.point.y <= 3.3f)
                    {
                        Vector3 PointSpavn = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                        Instantiate(_prefab, PointSpavn, Quaternion.identity);
                        PlaceBigTower = false;
                        goldController.BuyTower(BigTower);
                    }
                }
            }
        }



        if (placesmalltower && Input.GetMouseButtonDown(0))
        {
            if (goldController.MyGold >= SmallTower)
            {
                Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.point.y <= 3.3)
                    {
                        Vector3 PointSpavn = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                        Instantiate(_Smallprefab, PointSpavn, Quaternion.identity);
                        placesmalltower = false;
                        goldController.BuyTower(SmallTower);
                    }
                }
            }
        }
    }
}
