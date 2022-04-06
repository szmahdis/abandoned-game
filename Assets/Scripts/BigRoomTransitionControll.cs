using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody))]
public class BigRoomTransitionControll : MonoBehaviour
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
            currentScore = PlayerPrefs.GetInt(Dictionary.BigRoomPuzzleSolvedNumbers);
            if (currentScore >= 1)
            {
                PlayerPrefs.DeleteAll();
                isCompleted = true;
                LoadNextScene();
            }
        }
    }
}