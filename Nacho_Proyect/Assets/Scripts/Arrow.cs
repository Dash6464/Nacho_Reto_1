using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    public float resetcont;
    public float speed;
    public bool isLeft;
    public Rigidbody2D rb;
    private float cont;
    public AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        cont = 0;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cont >= resetcont)
        {
            Destroy(gameObject);
            cont = 0;
        }
        else
        {
            if (isLeft)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                transform.localScale = new Vector3(-0.7f, 0.7f, 1f);
            }
            else
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                transform.localScale = new Vector3(0.7f, 0.7f, 1f);
            }
            cont += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Escudo")
        {
            Destroy(gameObject);
            Arrow_SFX.Instance.ejecutarSonido(audioClip);
        }
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
            Destroy(gameObject);
        }
    }
}
