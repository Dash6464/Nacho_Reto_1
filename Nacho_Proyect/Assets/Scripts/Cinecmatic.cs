using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cinecmatic : MonoBehaviour
{
    [SerializeField]
    private UnityEvent evento;

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Player")
        {
            evento.Invoke();
        }
    }
}
