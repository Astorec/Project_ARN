﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    public float moveSpeed;
    public float jumpHeight;
    public float groundCheckRadius;
    public float gravity;

    private bool grounded;
    private bool doubleJumped;

    private Animator anim;
    private SpriteRenderer sr;


    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        
    }

    private void Update()
    {
        float direction = Input.GetAxisRaw("Horizontal");
        if (direction > 0)
            rb2D.velocity = new Vector2(1 * moveSpeed, rb2D.velocity.y);
        else if (direction < 0)
            rb2D.velocity = new Vector2(-1 * moveSpeed, rb2D.velocity.y);
        else if (direction == 0)
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);

        if (rb2D.velocity.x > 0)
        {
            sr.flipX = false;
            anim.SetBool("Left", false);
            anim.SetBool("Right", true);
        }

        else if (rb2D.velocity.x < 0)
        {
            sr.flipX = true;
            anim.SetBool("Right", false);
            anim.SetBool("Left", true);
        }

        if (grounded)
            doubleJumped = false;

        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Jump Height", rb2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
            Jump();

        if (Input.GetKeyDown(KeyCode.Space) && !doubleJumped && !grounded)
        {
            Jump();
            doubleJumped = true;
        }

        anim.SetFloat("Speed", (rb2D.velocity.x));

    }

    public void Jump()
    {
        rb2D.velocity = new Vector2(rb2D.velocity.x, jumpHeight);
    }

    private void CharacterMovement(float horizontalMovement)
    {
        rb2D.AddForce(new Vector2(horizontalMovement * moveSpeed * Time.deltaTime, 0));
    }
}