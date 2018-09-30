using UnityEngine;

public class jump : MonoBehaviour
{
    [Range(1, 10)]
    public float jumpVel;

    public Rigidbody2D rb2d;

    public void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("JUMP!!!");
            rb2d.velocity = Vector2.up * jumpVel;
        }
	}
}
