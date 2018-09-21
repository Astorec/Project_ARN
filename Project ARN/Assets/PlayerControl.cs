using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float speed = 5f;
    public float jump = 5f;
    
    private Vector2 moveSpeed;
    private Vector2 jumpSpeed;
    public Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), 0);        
        moveSpeed = movement * speed;       
        Vector2 jumpForce = new Vector2(0, Input.GetAxis("Jump"));
        jumpSpeed = jumpForce * jump;
        
    }
    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + moveSpeed * Time.fixedDeltaTime);
        rb2d.MovePosition(rb2d.position + jumpSpeed * Time.fixedDeltaTime);
    }

}
