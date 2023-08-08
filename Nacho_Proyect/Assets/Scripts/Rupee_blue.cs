using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rupee_blue : MonoBehaviour
{
    // Start is called before the first frame update
    public Points puntaje;
    public AudioClip audioClip;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Rupie_SFX.Instance.ejecutarSonido(audioClip);
            puntaje.SumarPuntos(5);
            Destroy(gameObject);
        }
    }
}
