using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OutdoorNote : Puzzle
{
    public GameObject notePanel;
    public AudioClip openAudioclip;
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
        yield return new WaitForSeconds(6f);
        audioSource.PlayOneShot(closeAudioclip);
        notePanel.gameObject.SetActive(false);
        yield return new WaitForSeconds(closeAudioclip.length);
        backgroundAudioController.audioSource.volume = 1f;

    }

    private static void IncreaseSolvedScore()
    {
        var currentSolvedPuzzles = PlayerPrefs.GetInt(Dictionary.OutdoorPuzzleSolvedNumbers, 0);
        currentSolvedPuzzles++;
        PlayerPrefs.SetInt(Dictionary.OutdoorPuzzleSolvedNumbers, currentSolvedPuzzles);
    }

}

