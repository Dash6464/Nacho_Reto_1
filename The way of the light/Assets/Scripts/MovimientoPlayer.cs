using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoPlayer : MonoBehaviour
{

    public float hspeed;

    private float hdir;

    public float vspeed;

    // private bool move = true;

    public Player_life _Life;

    private bool jump = true;

    private bool attack = true;

    private bool mirandoIzq = true;

    private Rigidbody2D Rb;

    private Animator animator;

    private PlayerInput playerInput;

    private Vector2 input;

    private bool jump_control;

    private bool attack_control;

    // Start is called before the first frame update
    void Awake()
    {
        Rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
    }
    void Update()
    {
        input = playerInput.actions["Move"].ReadValue<Vector2>();
        jump_control = playerInput.actions["Jump"].IsPressed();
        attack_control = playerInput.actions["Attack"].IsPressed();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.ToString() == "link_attack") &&
        !(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.ToString() == "link_jumpend") &&
        !(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.ToString() == "link_hit")
        )
        {
            hdir = input.x;
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

        if (jump_control && jump && !(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.ToString() == "link_attack") &&
        !(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.ToString() == "link_jumpend") &&
        !(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.ToString() == "link_hit"))
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

        if (attack_control && attack && !(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.ToString() == "link_jumpend") &&
        !(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.ToString() == "link_hit"))
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
        if (collision.gameObject.tag == "Piso" || collision.gameObject.tag == "Plat_Mov_Ver" || collision.gameObject.tag == "Plat_Caida")
        {
            animator.SetBool("Suelo", true);
            jump = true;
        }
        else
        {
            animator.SetBool("Suelo", false);
            jump = false;
        }

        if (collision.gameObject.tag == "Pared")
        {
            if (Rb.velocity.y != 0)
            {
                animator.SetBool("Suelo", false);
            }
            else
            {
                animator.SetBool("Suelo", true);
            }
        }

        if (collision.gameObject.tag == "Plat_Mov_Ver")
        {
            transform.parent = collision.transform;
        }

        if (collision.gameObject.tag == "Mummy" || collision.gameObject.tag == "Zora")
        {
            animator.SetTrigger("Hit");

            _Life.vida--;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Plat_Mov_Ver")
        {
            transform.parent = null;
        }

        // if (collision.gameObject.tag == "Piso" || collision.gameObject.tag == "Plat_Mov_Ver")
        // {
        //     animator.SetBool("Suelo", false);
        //     jump = false;
        // }
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Abismo")
        {
            _Life.vida = 0;
        }
    }

}
