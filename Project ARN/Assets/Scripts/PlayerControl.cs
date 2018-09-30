using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5f;
    

    private Vector2 moveSpeed;
    public Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), 0);
        moveSpeed = movement * speed;
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + moveSpeed * Time.fixedDeltaTime);
    }
}
