using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int objectLength = FindObjectsOfType<MusicPlayer>().Length;
        if (objectLength > 1)
            Destroy(gameObject);
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
