using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeMainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void SetVolume(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);

    }

    public void SetVolumeEffects(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("Effects", Mathf.Log10(volume) * 20);

    }

    public void SetVolumeMusic(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);

    }

}