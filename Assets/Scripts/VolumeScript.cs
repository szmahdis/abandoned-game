using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeScript : MonoBehaviour
{
    public AudioMixer audioMixer;
    public PauseMenu pause;
    public void SetVolume(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
        
    }

    public void SetVolumeEffects(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("Effects", Mathf.Log10(volume) * 20);
        audioMixer.GetFloat("Effects",out volume);
        pause.audioValue = volume;
    }

    public void SetVolumeMusic(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);

    }

}
