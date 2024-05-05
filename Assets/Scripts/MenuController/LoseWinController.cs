using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseWinController : MonoBehaviour
{
    [SerializeField] private GameObject LosePanel;
    [SerializeField] private GameObject WinPanel;
    void Start()
    {
        LosePanel.SetActive(false);
        WinPanel.SetActive(false);
    }

    public void Lose()
    {
        LosePanel.SetActive(true);
    }
    public void NextLevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex + 1);
    }
    private void Win()
    {
        WinPanel.SetActive(true);
    }
    
}
