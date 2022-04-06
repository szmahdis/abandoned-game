using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudioController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip mainThemeAudio;


    private void Awake()
    {

        audioSource = this.GetComponent<AudioSource>();
        audioSource.clip = mainThemeAudio;
        audioSource.Play();
    }
}
