using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_life : MonoBehaviour
{
    public int vida;
    public GameObject[] corazones;

    void Start()
    {
        vida = corazones.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (vida < 3)
        {
            corazones[2].SetActive(false);
        }
        if (vida < 2)
        {
            corazones[1].SetActive(false);
        }
        if (vida < 1)
        {
            corazones[0].SetActive(false);
            SceneManager.LoadScene("Game_over");
        }
    }
}
