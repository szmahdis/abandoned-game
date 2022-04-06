using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioPuzzle : Puzzle
{

    public AudioClip morseCode;
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
        var currentSolvedPuzzles = PlayerPrefs.GetInt(Dictionary.BigRoomPuzzleSolvedNumbers, 0);
        currentSolvedPuzzles++;
        PlayerPrefs.SetInt(Dictionary.BigRoomPuzzleSolvedNumbers, currentSolvedPuzzles);
    }

    private IEnumerator EffectCoroutine()
    {
        backgroundAudioController.audioSource.volume = 0.5f;
        audioSource.PlayOneShot(morseCode);
        yield return new WaitForSeconds(15);
        backgroundAudioController.audioSource.volume = 1f;


    }

}
