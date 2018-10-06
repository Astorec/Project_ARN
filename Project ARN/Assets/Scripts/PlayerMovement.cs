using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D conrtoller;

    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;

    float horizontalMovement = 0f;

	void Update () {
        Debug.Log(jump);
        horizontalMovement = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
	}

    private void FixedUpdate()
    {
        conrtoller.Move(horizontalMovement * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        crouch = true;
    }
}
