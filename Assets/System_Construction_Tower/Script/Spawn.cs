using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    public GameObject bigtower;
    public GameObject smalltower;
    public Text TextMoney;

    private int Money;
    private const int BigTower = 2000;
    private const int SmallTower = 500;

    RaycastHit hit;
    [SerializeField] private GameObject _prefab;
    private Camera _mainCamera;
    void Start()
    {
        _mainCamera = Camera.main;
        BuyTower();
    }

    private void Update()
    {
       { Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
          if (Input.GetMouseButtonDown(0))
          {
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 PointSpavn = new Vector3(hit.point.x, hit.point.y + 0.5f, hit.point.z);
                GameObject newObject = Instantiate(_prefab, PointSpavn, Quaternion.identity);
                Renderer objectRenderer = newObject.GetComponent<Renderer>();
                objectRenderer.material.color = new(hit.point.x, hit.point.y + 0.5f, hit.point.z);
            }
          }          
       }
    }
    public void BuyTower()
    {
        if(Money >= BigTower)
        {

        }
        

    }

    public void BuyTower2()
    {
        if (Money >= SmallTower)
        {
            Money -= SmallTower;
            Instantiate(smalltower, Vector3.zero, Quaternion.identity);
        }

    }
}





