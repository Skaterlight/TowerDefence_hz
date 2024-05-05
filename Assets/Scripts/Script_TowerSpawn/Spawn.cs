using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;


public class Spawn : MonoBehaviour
{ 
    public Text TextMoney;
    private int Money = 5000;
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
        TextMoney.text = Money.ToString();
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
            if (Money >= BigTower)
            {
               

                Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
               
                if (Physics.Raycast(ray, out hit))
                {
                    if(hit.collider.gameObject.name == "Platform")
                    {
                        Vector3 PointSpavn = new Vector3(hit.point.x, hit.point.y, hit.point.z);               
                        Instantiate(_prefab, PointSpavn, Quaternion.identity);
                        PlaceBigTower = false;
                            Money -= BigTower;
                            TextMoney.text = Money.ToString();
                    }
                }                
            }
        }
        if (placesmalltower && Input.GetMouseButtonDown(0))
        {
            if (Money >= SmallTower)
            {
                Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    if(hit.collider.gameObject.name == "Platform")
                    { 
                      Vector3 PointSpavn = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                       
                        Instantiate(_Smallprefab, PointSpavn, Quaternion.identity);
                      placesmalltower = false;
                        Money -= SmallTower;
                        TextMoney.text = Money.ToString();
                    }
                   
                }
            }
        }
    }    
}





