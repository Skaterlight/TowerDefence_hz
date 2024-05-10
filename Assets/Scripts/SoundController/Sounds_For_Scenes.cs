using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds_For_Scenes : MonoBehaviour
{
    public AudioClip[] sounds;

    private AudioSource audioScr => GetComponent<AudioSource>();

    // Sours for Enemy 
    public void PlaySound (AudioClip clip, float volume = 1f, bool destroy = false , float p1= 0.85f, float p2 = 1.1f)
    {
        audioScr.pitch = Random.Range(p1, p2);
        audioScr.PlayOneShot(clip, volume);
       
        if(destroy )
        {
            AudioSource.Destroy(clip,volume);
        }
    }



}
