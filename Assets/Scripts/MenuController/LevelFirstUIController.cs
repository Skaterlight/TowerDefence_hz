using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelFirstUIController : MonoBehaviour
{
    public Slider slider;
    public AudioSource audioSource;
    public GameObject Panel;
    public GameObject StorePanel;
    public GameObject WannaExitPanel;
    public Button pauseButton;
    public string pauseText;
    private bool soundIsActive;
    private bool isPaused;
    private bool escChecker = true;


    void Start()
    {

        StorePanel.SetActive(false);
        WannaExitPanel.SetActive(false);
        Panel.SetActive(false);
        slider.value = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        { 
          Panel.SetActive(true);
            
            if (escChecker)
            {
                PauseGame();
            }
        }
        audioSource.volume = slider.value;
        if (Input.GetKeyDown(KeyCode.M))
        {
            StorePanel.SetActive(true);
        }
        
    }
    public void PauseGame()
    {
        if (isPaused == false)
        {
            Time.timeScale = 0f;
            isPaused = true;
            Debug.Log(Time.timeScale);
            
        }
        else if (isPaused == true)
        {
            Time.timeScale = 1.0f;
            isPaused = false;
            Debug.Log(Time.timeScale);
            
        }
        
    }
    public void WannaLoadMainMenu()
    {
        WannaExitPanel.SetActive(true);

    }
    public void Resume()
    {
        Panel.SetActive(false);

    }
    public void NoIWillStay()
    {
        WannaExitPanel.SetActive(false);
    }
    public void YesIWillGo()
    {
        SceneManager.LoadScene(0);
    }
    public void OpenStore()
    {

    }
    public void BuyGun()
    {
        Debug.Log("You Bought a gun");
    }
    public void CloseStorePanel()
    {
        StorePanel.SetActive(false);
    }

}
