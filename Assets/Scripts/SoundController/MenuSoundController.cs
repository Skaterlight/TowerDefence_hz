using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSoundController : MonoBehaviour
{
    public Slider slider;
    public AudioSource audioSource;
    void Start()
    {
        
    }

    public void OnValueChanged()
    {
        audioSource.volume = slider.value;
    }
}
