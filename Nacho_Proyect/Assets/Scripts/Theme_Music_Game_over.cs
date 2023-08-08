using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Theme_Music_Game_over : MonoBehaviour
{
    public static Theme_Music_Game_over instance = null;
    public AudioSource audio;

    private void Start()
    {
        audio.Play();
    }

    private void Update()
    {
        if (instance == null)
        {
            if (SceneManager.GetActiveScene().name.ToString() == "Presentation" ||
            SceneManager.GetActiveScene().name.ToString() == "Level_1" ||
            SceneManager.GetActiveScene().name.ToString() == "Temple_Ice")
            { Destroy(instance); }
            else
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
                return;
            }
        }
        if (instance == this) return;
        Destroy(gameObject);
    }
}