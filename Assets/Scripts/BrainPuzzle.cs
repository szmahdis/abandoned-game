using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainPuzzle : Puzzle
{
    public AudioClip brainAudioclip;
    public AudioClip roomAudioclip;
    private AudioSource audioSource;
    public Light roomLight;
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
        var currentSolvedPuzzles = PlayerPrefs.GetInt(Dictionary.CorridorPuzzleSolvedNumbers, 0);
        currentSolvedPuzzles++;
        PlayerPrefs.SetInt(Dictionary.CorridorPuzzleSolvedNumbers, currentSolvedPuzzles);
    }

    private IEnumerator EffectCoroutine()
    {
        backgroundAudioController.audioSource.volume = 0.7f;
        audioSource.PlayOneShot(brainAudioclip);
        yield return new WaitForSeconds(brainAudioclip.length);
        roomLight.color = Color.red;
        audioSource.PlayOneShot(roomAudioclip);
        yield return new WaitForSeconds(0.5f);
        backgroundAudioController.audioSource.volume = 1f;


    }
}
