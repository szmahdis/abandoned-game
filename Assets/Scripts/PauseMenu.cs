using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool gamePause = false;
    public GameObject pauseMenuUi;
    public AudioMixer audioMixer;
    public float audioValue;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        gamePause = false;
        audioMixer.SetFloat("Effects", audioValue);
    }

    public void Pause()
    {
        pauseMenuUi.SetActive(true);
        audioMixer.GetFloat("Effects", out audioValue);
        audioMixer.SetFloat("Effects", -80f);
        Time.timeScale = 0f;
        gamePause = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
