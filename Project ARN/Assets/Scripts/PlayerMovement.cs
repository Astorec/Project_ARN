using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    public float runSpeed = 40f;
    public float jumpForce = 500f;
    public Rigidbody2D rb2d;
    public Transform groundCheck;

    bool grounded = false;
    bool facingRight = true;
	
	// Update is called once per frame
	void FixedUpdate () {

        float moveHorizontal = Input.GetAxisRaw("Horizontal");

        if(moveHorizontal != 0)
        {
            transform.Translate(new Vector2(moveHorizontal * runSpeed * Time.fixedDeltaTime, 0));
        }

        //TODO Make Character flip when moving to face correct direction

        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));


        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb2d.AddForce(new Vector2(0, jumpForce));
            grounded = false;
        }
   
        
	}

    
}
