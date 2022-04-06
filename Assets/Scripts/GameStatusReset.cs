using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatusReset : MonoBehaviour
{
    private void Awake()
    {
        ResetPlayerPrefs();
    }

    private void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
