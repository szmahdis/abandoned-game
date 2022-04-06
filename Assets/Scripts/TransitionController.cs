using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody))]
public class TransitionController : MonoBehaviour
{
    public bool isCompleted;
    public string sceneToLoad;
    private int currentScore;

    private void LoadNextScene()
    {
        if(isCompleted)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            currentScore = PlayerPrefs.GetInt(Dictionary.CorridorPuzzleSolvedNumbers);
            if(currentScore==3)
            {
                isCompleted = true;
                LoadNextScene();
            }
        }
    }
}
