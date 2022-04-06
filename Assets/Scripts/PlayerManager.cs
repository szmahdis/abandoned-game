using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{

    #region Singleton

    public static PlayerManager instace;

    #endregion

    public GameObject gameOverUi;
    public GameObject player;

    void Awake()
    {
        instace = this;
    }

    public void KillPlayer()
    {
        gameOverUi.SetActive(true);
        Time.timeScale = 0f;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
