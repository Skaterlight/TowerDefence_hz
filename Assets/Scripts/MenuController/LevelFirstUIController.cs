using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelFirstUIController : MonoBehaviour
{
    [SerializeField] Slider slider;
    public AudioSource audioSource;
    public AudioSource buttonSoundSource;
    public AudioSource buttonSoundSource2;
    public AudioSource buttonSoundSource3;
    public GameObject Panel;
    [SerializeField] private GameObject MainMenuPanel;
    public GameObject WannaExitPanel;
    public string pauseText;
    private bool soundIsActive;
    private bool isPaused;
    private bool panelIsActive;
    private int screenResolutionToChange;
    

    void Start()
    {
        MainMenuPanel.SetActive(true);
        WannaExitPanel.SetActive(false);
        Panel.SetActive(false);
        slider.value = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (!panelIsActive)
            {
                Panel.SetActive(true);
                PauseGame();
                panelIsActive = true;
            }
            else
            {
                Panel.SetActive(false);
                ResumeGame();
                panelIsActive = false;
            }
        }
        audioSource.volume = slider.value;
        
        
        
    }

    public void RestartLevel()
    {
        int getLevelIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(getLevelIndex);
    }
    public void PauseGame()
    {
        if (!isPaused)
        {
            Time.timeScale = 0f;
            isPaused = true;
            Debug.Log(Time.timeScale);
        }
    }
    public void ButtonPressed() 
    {
        buttonSoundSource.Play();
    }
    public void ButtonPressed2()
    {
        buttonSoundSource2.Play();
    }
    public void ButtonPressed3()
    {
        buttonSoundSource3.Play();
    }
    private void PlayerLost()
    {

    }
    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
        Debug.Log(Time.timeScale);
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
    
    
    
    
}
