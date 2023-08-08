using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Rupee_green : MonoBehaviour
{
    public Points puntaje;
    public AudioClip audioClip;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Rupie_SFX.Instance.ejecutarSonido(audioClip);
            puntaje.SumarPuntos(1);
            Destroy(gameObject);
        }
    }

}
