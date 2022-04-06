using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollPuzzle : Puzzle
{

    private const int thrust = 100;
    public AudioClip dollAudio;
    public AudioClip dollFall;
    public AudioClip keySound;
    private AudioSource audioSource;
    private Rigidbody rb;
    public BackgroundAudioController backgroundAudioController;


    public void Start()
    {
        // to assign audio source to the object
        audioSource = this.GetComponent<AudioSource>();
        rb = this.GetComponent<Rigidbody>();
    }
    public override void DetectionEffects()
    {
        StartCoroutine(EffectCoroutine());
        IncreaseSolvedScore();
    }

    private IEnumerator EffectCoroutine()
    {
        backgroundAudioController.audioSource.volume = 0.5f;
        audioSource.PlayOneShot(dollAudio);
        yield return new WaitForSeconds(dollAudio.length);
        rb.AddForce(Vector3.back * thrust);
        audioSource.PlayOneShot(dollFall);
        yield return new WaitForSeconds(dollFall.length);
        GameObject key = GameObject.Find("rust_key");
        key.GetComponent<MeshRenderer>().enabled = false;
        audioSource.PlayOneShot(keySound);
        backgroundAudioController.audioSource.volume = 1f;

    }


    private static void IncreaseSolvedScore()
    {
        var currentSolvedPuzzles = PlayerPrefs.GetInt(Dictionary.CorridorPuzzleSolvedNumbers, 0);
        currentSolvedPuzzles++;
        PlayerPrefs.SetInt(Dictionary.CorridorPuzzleSolvedNumbers, currentSolvedPuzzles);
    }
}
