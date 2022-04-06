using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public Text timerText;
    public GameObject notePanel;

    public AudioClip gameOver;
    private AudioSource audioSource;
    public BackgroundAudioController backgroundAudioController;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        audioSource = this.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                StartCoroutine(EffectCoroutine());
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private IEnumerator EffectCoroutine()
    {
        backgroundAudioController.audioSource.volume = 0.5f;
        notePanel.gameObject.SetActive(true);
        audioSource.PlayOneShot(gameOver);
        yield return new WaitForSeconds(10);
        backgroundAudioController.audioSource.volume = 1f;
        SceneManager.LoadScene(0);
    }
}