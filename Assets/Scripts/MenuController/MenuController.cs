using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System;

public class MenuController : MonoBehaviour
{
    public AudioSource audioSource;
    private float musicLoud; 

    public GameObject MainMenuPanel;
    public GameObject settingsMenuPanel;
    public GameObject levelsMenuPanel;
    private void Start()
    {
        LoadMainMenu();
    }

    public void LoadMainMenu()
    {
        MainMenuPanel.SetActive(true);
        settingsMenuPanel.SetActive(false);
        levelsMenuPanel.SetActive(false);
    }
    public void ChooseLevel()
    {
        MainMenuPanel.SetActive(false);
        settingsMenuPanel.SetActive(false);
        levelsMenuPanel.SetActive(true);
    }
    public void OpenSettings()
    {
        MainMenuPanel.SetActive(false);
        levelsMenuPanel.SetActive(false);
        settingsMenuPanel.SetActive(true);
    }
    public void LoadLevelOne()
    {
        
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
