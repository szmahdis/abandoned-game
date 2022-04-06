using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTheme : MonoBehaviour
{
    public static MainTheme instance;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }


        DontDestroyOnLoad(gameObject);
        AudioSource audioSource = this.GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
