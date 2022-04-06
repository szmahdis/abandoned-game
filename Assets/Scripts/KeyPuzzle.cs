using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPuzzle : Puzzle
{
    public AudioClip keyAudioclip;
    private AudioSource audioSource;
    public BackgroundAudioController backgroundAudioController;


    private void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }
    public override void DetectionEffects()
    {
        StartCoroutine(EffectCoroutine());
        IncreaseSolvedScore();
    }

    private static void IncreaseSolvedScore()
    {
        var currentSolvedPuzzles = PlayerPrefs.GetInt(Dictionary.WakeUpPuzzleSolvedNumbers, 0);
        currentSolvedPuzzles++;
        PlayerPrefs.SetInt(Dictionary.WakeUpPuzzleSolvedNumbers, currentSolvedPuzzles);
    }


    private IEnumerator EffectCoroutine()
    {
        backgroundAudioController.audioSource.volume = 0.7f;
        audioSource.PlayOneShot(keyAudioclip);
        GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(keyAudioclip.length);
        backgroundAudioController.audioSource.volume = 1f;
    }
}
