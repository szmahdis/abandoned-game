using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody))]
public class WakeUpTransitionController : MonoBehaviour
{
    public bool isCompleted;
    public string sceneToLoad;
    private int currentScore;

    private void LoadNextScene()
    {
        if (isCompleted)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            currentScore = PlayerPrefs.GetInt(Dictionary.WakeUpPuzzleSolvedNumbers);
            if (currentScore >= 2 )
            {
                PlayerPrefs.DeleteAll();
                isCompleted = true;
                LoadNextScene();
            }
        }
    }
}