using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public GameObject notePanel;
    public AudioSource noteSound;

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player hit sphere!");
            notePanel.gameObject.SetActive(true);
            noteSound.Play();
            yield return new WaitForSeconds(10);
            notePanel.gameObject.SetActive(false);
            SceneManager.LoadScene(0);
        }
    }


}
