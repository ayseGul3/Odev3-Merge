using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharacterController2 : MonoBehaviour
{
    public float jumpForce=2.0f;
    public float speed=1.0f;
    public float moveDireciton;
   

    private bool jump;
    private bool grounded=true;
    private bool moving;

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Animator anim;

     void Awake()
    {
        anim = GetComponent<Animator>();
    }
     void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        if (_rigidbody2D.velocity != Vector2.zero)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
        
        _rigidbody2D.velocity = new Vector2(speed * moveDireciton, _rigidbody2D.velocity.y);
        if (jump == true)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
            jump = false;

        }
    }
    private void Update()
    {
        if(grounded==true && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDireciton = -1.0f;
                _spriteRenderer.flipX = true;
                anim.SetFloat("speed", speed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDireciton = 1.0f;
                _spriteRenderer.flipX = false; 
                anim.SetFloat("speed", speed);
            }
        }
        else if (grounded == true)
        {
            moveDireciton = 0.0f;
            anim.SetFloat("speed", 0.0f);

        }

        if(grounded==true && Input.GetKey(KeyCode.W))
        {
            jump = true;
            grounded=false;
            anim.SetTrigger("jump");
            anim.SetBool("grounded", false);


        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("zemin"))
        {
            anim.SetBool("grounded", true);
            grounded = true;

        }

    }

}
