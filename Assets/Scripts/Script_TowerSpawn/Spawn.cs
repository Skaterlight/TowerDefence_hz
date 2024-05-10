using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;


public class Spawn : Sounds_For_Scenes 
{
    GoldController goldController;
    
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
    }

    public void Update()
    {
        OnButtonDown();
    }
    public void placebigtower()
    {
        PlaceBigTower = true;
    }
    public void PlaceSmalltower()
    {
        placesmalltower = true;

    }

    public void OnButtonDown()
    {

        if(PlaceBigTower && Input.GetMouseButtonDown(0))
        {
            if (goldController.MyGold >= BigTower)
            {
               

                Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
               
                if (Physics.Raycast(ray, out hit))
                {
                    if(hit.collider.gameObject.name == "Platform")
                    {
                        Vector3 PointSpavn = new Vector3(hit.point.x, hit.point.y, hit.point.z);               
                        Instantiate(_prefab, PointSpavn, Quaternion.identity);
                      //  PlaySound(sounds[0]);
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
                    if(hit.collider.gameObject.name == "Platform")
                    { 
                      Vector3 PointSpavn = new Vector3(hit.point.x, hit.point.y, hit.point.z);                 
                        Instantiate(_Smallprefab, PointSpavn, Quaternion.identity);
                      //  PlaySound(sounds[0]);
                        placesmalltower = false;
                        goldController.BuyTower(SmallTower);
                    }
                   
                }
            }
        }
    }    
}





