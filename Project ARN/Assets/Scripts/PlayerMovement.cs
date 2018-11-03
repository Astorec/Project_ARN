using System.Collections;
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

    private bool grounded;
    private bool doubleJumped;

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    private void Update()
    {

         if (Input.GetKey(KeyCode.A))
            rb2D.velocity = new Vector2(-moveSpeed, rb2D.velocity.y * Time.fixedDeltaTime);
        
        if (Input.GetKey(KeyCode.D))
            rb2D.velocity = new Vector2(moveSpeed, rb2D.velocity.y * Time.fixedDeltaTime);        

        if (grounded)
            doubleJumped = false;

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
            Jump();
        

        if (Input.GetKeyDown(KeyCode.Space) && !doubleJumped && !grounded)
        {
            Jump();
            doubleJumped = true;
        }

       
    }

    public void Jump()
    {
        rb2D.velocity = new Vector2(rb2D.velocity.x, jumpHeight);
    }
}