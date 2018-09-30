using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    public float runSpeed = 40f;
    public float jumpForce = 500f;
    public Rigidbody2D rb2d;

    float moveHorizontal = 0f;
    float velocity = 0f;
    bool jump = false;

	// Use this for initialization
	void Update () {

        moveHorizontal = Input.GetAxisRaw("Horizontal") * runSpeed;

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        

        if (Input.GetButtonDown("Jump"))
        {
            rb2d.AddForce(new Vector2(0, jumpForce));
            jump = true;
        }
        
        jump = false;
	}
}
