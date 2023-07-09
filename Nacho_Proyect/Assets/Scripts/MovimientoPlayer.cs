using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{

    public float hspeed;

    private float hdir;

    public float vspeed;

    // private bool move = true;

    private bool jump = true;

    private bool attack = true;

    private bool mirandoIzq = true;

    private Rigidbody2D Rb;

    private Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        Rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.ToString() == "link_attack") && !(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.ToString() == "link_jumpend"))
        {
            hdir = Input.GetAxis("Horizontal");
            Rb.velocity = new Vector2(Mathf.Round(hdir) * hspeed, Rb.velocity.y);
            animator.SetFloat("hspeed", Mathf.Round(Mathf.Abs(hdir)));

            if (hdir < 0 && mirandoIzq)
            {
                Flip();
            }

            if (hdir > 0 && !mirandoIzq)
            {
                Flip();
            }
        }

        if (Input.GetKeyDown(KeyCode.J) && jump && !(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.ToString() == "link_attack") && !(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.ToString() == "link_jumpend"))
        {
            Rb.velocity = new Vector2(Rb.velocity.x, vspeed);
            animator.SetBool("Suelo", false);
            animator.SetFloat("vspeed", Rb.velocity.y);
            jump = false;
        }
        else
        {
            animator.SetFloat("vspeed", Rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.K) && attack && !(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.ToString() == "link_jumpend"))
        {
            animator.SetTrigger("Attack");
            attack = false;
        }
        else
        {
            attack = true;
        }

    }

    void Flip()
    {
        Vector3 scale = gameObject.transform.localScale;
        scale.x *= -1;
        gameObject.transform.localScale = scale;

        mirandoIzq = !mirandoIzq;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Piso")
        {
            animator.SetBool("Suelo", true);
            jump = true;
        }
        else
        {
            animator.SetBool("Suelo", false);
            jump = false;
        }
    }

}
