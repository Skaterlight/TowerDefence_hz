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
    public GameObject Level1Panel;
    public GameObject Level2Panel;
    public GameObject Level3Panel;
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
        Level1Panel.SetActive(false);
        Level2Panel.SetActive(false);
        Level3Panel.SetActive(false);
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
    public void LoadLevel1Panel()
    {
        Level1Panel.SetActive(true);
    }
    public void CloseLevel1Panel()
    {
        Level1Panel.SetActive(false);
    }
    public void CloseLevel2Panel()
    {
        Level2Panel.SetActive(false);
    }
    public void CloseLevel3Panel()
    {
        Level3Panel.SetActive(false);
    }
    public void LoadLevel2Panel()
    {
        Level2Panel.SetActive(true);
    }
    public void LoadLevel3Panel()
    {
        Level3Panel.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
