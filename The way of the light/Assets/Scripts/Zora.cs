using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zora : MonoBehaviour
{
    // Start is called before the first frame update
    public float minX;
    public float maxX;
    public float TiempoEspera = 2f;
    public float Velocidad;
    public bool izquierda;
    public Zora_bull ice_bull;
    public GameObject zora_bull;

    private GameObject lugarObjetivo;

    // Start is called before the first frame update
    void Start()
    {
        UpdateObjetivo();
        StartCoroutine("Patrullar");
    }

    private void UpdateObjetivo()
    {
        if (lugarObjetivo == null)
        {
            lugarObjetivo = new GameObject("Sitio_objetivo");
            lugarObjetivo.transform.position = new Vector2(minX, transform.position.y);
            transform.localScale = new Vector3(1.65f, 1.65f, 1);
            lugarObjetivo.SetActive(true);
            return;
        }

        if (lugarObjetivo.transform.position.x == minX)
        {
            lugarObjetivo.transform.position = new Vector2(maxX, transform.position.y);
            transform.localScale = new Vector3(-1.65f, 1.65f, 1);
            izquierda = false;
        }

        else if (lugarObjetivo.transform.position.x == maxX)
        {
            lugarObjetivo.transform.position = new Vector2(minX, transform.position.y);
            transform.localScale = new Vector3(1.65f, 1.65f, 1);
            izquierda = true;
        }
    }

    private IEnumerator Patrullar()
    {
        while (Vector2.Distance(transform.position, lugarObjetivo.transform.position) > 0.05f)
        {
            Vector2 direction = lugarObjetivo.transform.position - transform.position;
            float xDirection = direction.x;

            transform.Translate(direction.normalized * Velocidad * Time.deltaTime);

            yield return null;
        }

        // Debug.Log("Se alcanzo el Objetivo");
        transform.position = new Vector3(lugarObjetivo.transform.position.x, transform.position.y, -1f);

        // Debug.Log("Esperando " + TiempoEspera + " Segundos");
        yield return new WaitForSeconds(TiempoEspera);

        if (izquierda)
        {
            ice_bull.isLeft = true;
            Instantiate(zora_bull, new Vector3(transform.position.x - 1.56f,
            transform.position.y + 0.85f, transform.position.z), Quaternion.identity
            );
        }
        else
        {
            ice_bull.isLeft = false;
            Instantiate(zora_bull, new Vector3(transform.position.x + 1.56f,
            transform.position.y + 0.85f, transform.position.z), Quaternion.identity
            );
        }


        // Debug.Log("Se espera lo que necesario para que termine y vuelva a empezar movimiento");
        UpdateObjetivo();
        StartCoroutine("Patrullar");

    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Player")
        {
            if (collision2D.gameObject.transform.position.x < transform.position.x)
            {
                collision2D.gameObject.transform.Translate(Vector3.right * -100f * Time.deltaTime, Space.Self);
                ;
            }

            if (collision2D.gameObject.transform.position.x > transform.position.x)
            {
                collision2D.gameObject.transform.Translate(Vector3.right * 100f * Time.deltaTime, Space.Self);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Espada")
        {
            Destroy(gameObject);
        }
    }
}
