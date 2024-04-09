using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnTower : MonoBehaviour
{
    public Text TextMoney;
    private int Money = 10000;
    private int TowerCost = 1000;
    private RaycastHit hit;
    [SerializeField] private GameObject _towerPrefab;
    private Camera _mainCamera;

    void Start()
    {
        TextMoney.text = Money.ToString();
        _mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Money >= TowerCost)
            {
                Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.point.y <= 3.3f)
                    {
                        Vector3 pointSpawn = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                        Instantiate(_towerPrefab, pointSpawn, Quaternion.identity);
                        Money -= TowerCost;
                        TextMoney.text = Money.ToString();
                    }
                }
            }
        }
    }
}
