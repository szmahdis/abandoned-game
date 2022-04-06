using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightScript : MonoBehaviour
{

    public bool flashlightOn = false;
    public GameObject lightsource;
    public AudioSource clickSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlightOn = !flashlightOn;
            lightsource.SetActive(flashlightOn);
            clickSound.Play();
            /*if (flashlightOn)
            {
                lightsource.SetActive(false);
                clickSound.Play();
                flashlightOn = false;
            }
            else
            {
                lightsource.SetActive(true);
                clickSound.Play();
                flashlightOn = true;
            }*/
        }
    }
}
