using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrollyPuzzle : Puzzle
{
    public GameObject notePanel;
    public AudioClip openAudioclip;
    public AudioClip breakingAudioclip;
    public AudioClip closeAudioclip;
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

    private IEnumerator EffectCoroutine()
    {
        backgroundAudioController.audioSource.volume = 0.7f;
        audioSource.PlayOneShot(openAudioclip);
        notePanel.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        audioSource.PlayOneShot(breakingAudioclip);
        yield return new WaitForSeconds(2f);
        audioSource.PlayOneShot(closeAudioclip);
        notePanel.gameObject.SetActive(false);
        yield return new WaitForSeconds(closeAudioclip.length);
        backgroundAudioController.audioSource.volume = 1f;

    }

    private static void IncreaseSolvedScore()
    {
        var currentSolvedPuzzles = PlayerPrefs.GetInt(Dictionary.CorridorPuzzleSolvedNumbers, 0);
        currentSolvedPuzzles++;
        PlayerPrefs.SetInt(Dictionary.CorridorPuzzleSolvedNumbers, currentSolvedPuzzles);
    }

}
