using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnTowerFull : MonoBehaviour
{
    public Text TextMoney;
    private int Money = 10000;
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

        Button button = GameObject.Find("ButtonBT").GetComponent<Button>();
        button.onClick.AddListener(placebigtower);

        Button button2 = GameObject.Find("ButtonMT").GetComponent<Button>();
        button2.onClick.AddListener(PlaceSmalltower);
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

        if (PlaceBigTower && Input.GetMouseButtonDown(0))
        {
            if (Money >= BigTower)
            {
                Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.point.y <= 3.3f)
                    {
                        Vector3 PointSpavn = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                        transform.rotation = Quaternion.Euler(hit.point.x, hit.point.y + 90f, hit.point.z);
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
                Money -= SmallTower;
                TextMoney.text = Money.ToString();

                Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.point.y <= 3.3)
                    {
                        Vector3 PointSpavn = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                        Instantiate(_Smallprefab, PointSpavn, Quaternion.identity);
                        placesmalltower = false;
                    }
                }
            }
        }
    }

}
