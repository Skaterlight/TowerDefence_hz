using UnityEngine;
using UnityEngine.UI;

public class GoldController : MonoBehaviour
{
    [SerializeField] private Text _goldText;

    private int _myGold;
    public int MyGold { get { return _myGold; } }

    private void Start()
    {
        _myGold = 500;
        UpdateGold();
    }

    public void UpdateGold()
    {
        _goldText.text = _myGold.ToString();
    }

    public void AddGold(int value)
    {
        _myGold += value;
        UpdateGold();
    }

    public void BuyTower(int cost)
    {
        if (_myGold >= cost)
        {
            _myGold -= cost;
            UpdateGold();
        }
    }
}
