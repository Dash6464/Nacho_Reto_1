using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    public AudioClip clicSound;
    public AudioClip hoverSound;
    public Button btn;
    public AudioSource audioSource;
    public TextMeshPro texto;
    public GameObject pauseMenu;

    public GameObject controlsMenuPause;

    // Start is called before the first frame update
    public void OnPointerClick(PointerEventData eventData)
    {
        audioSource.clip = clicSound;
        audioSource.Play();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.clip = hoverSound;
        audioSource.Play();
    }

    public void cambiarEscena(string escena)
    {
        SceneManager.LoadScene(escena);
    }

    public void entrarEscenaGameOver(string escena)
    {
        Theme_Music_Game_over.instance.audio.Stop();
        SceneManager.LoadScene(escena);
    }

    public void iniciarJuego(string escena)
    {
        Theme_Menu.instance.audio.Stop();
        SceneManager.LoadScene(escena);
    }

    public void salirJuego()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    // public void SoundState()
    // {
    //     if (sound)
    //     {
    //         texto.text = "SOUND : ON";
    //     }
    //     else
    //     {
    //         texto.text = "SOUND : OFF";
    //     }
    //     Debug.Log("" + !sound);
    //     sound = !sound;
    // }

    public void pausa()
    {
        pauseMenu.SetActive(true);
        // Pause.SetActive(false);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    public void continuar()
    {
        //Debug.Log("continuar");
        pauseMenu.SetActive(false);
        // Pause.SetActive(true);
        Time.timeScale = 1;
    }

    public void controlsShow()
    {
        //Debug.Log("pausa");
        controlsMenuPause.SetActive(true);
    }

    // Update is called once per frame
    public void controlsHide()
    {
        //Debug.Log("continuar");
        controlsMenuPause.SetActive(false);
    }
}