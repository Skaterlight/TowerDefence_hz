using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseWinController : MonoBehaviour
{
    [SerializeField] private GameObject LosePanel;
    [SerializeField] private GameObject WinPanel;
    void Start()
    {
        LosePanel.SetActive(false);
        WinPanel.SetActive(false);
    }

    private void Lose()
    {
        LosePanel.SetActive(true);
    }
    private void Win()
    {
        WinPanel.SetActive(true);
    }
    void Update()
    {
        
    }
}
