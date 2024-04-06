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
    private bool soundIsActive;
    void Start()
    {
        Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        { 
          Panel.SetActive(true); 
        }
        audioSource.volume = slider.value;
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
}
