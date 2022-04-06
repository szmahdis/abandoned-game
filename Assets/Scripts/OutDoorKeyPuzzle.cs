using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutDoorKeyPuzzle : Puzzle
{
    // Start is called before the first frame update
    public AudioClip keyAudioclip;
    public GameObject interaction;
    public GameObject gate;
    public GameObject gateOpen;
    public GameObject lights;
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
        lights.SetActive(false);
        interaction.SetActive(true);
        gate.SetActive(false);
        gateOpen.SetActive(true);
        GetComponent<MeshRenderer>().enabled = false;
        backgroundAudioController.audioSource.volume = 0.7f;
        audioSource.PlayOneShot(keyAudioclip);
        GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(keyAudioclip.length);
        backgroundAudioController.audioSource.volume = 1f;

    }

    private static void IncreaseSolvedScore()
    {
        var currentSolvedPuzzles = PlayerPrefs.GetInt(Dictionary.OutdoorPuzzleSolvedNumbers, 0);
        currentSolvedPuzzles++;
        PlayerPrefs.SetInt(Dictionary.OutdoorPuzzleSolvedNumbers, currentSolvedPuzzles);
    }
}
