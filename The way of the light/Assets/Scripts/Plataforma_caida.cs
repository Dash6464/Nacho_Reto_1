using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma_caida : MonoBehaviour
{
    public float TiempoEspera = 2f;

    private bool caida = false;

    private IEnumerator Caida()
    {
        Debug.Log(caida);
        if (caida)
        {
            yield return new WaitForSeconds(TiempoEspera);

            Destroy(gameObject);
        }

    }
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Player")
        {
            caida = true;
            StartCoroutine(Caida());
        }
    }
}
