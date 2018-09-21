using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float speed = 5f;
    public float jumpSpeed = 5f;

    public Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        rb2d.MovePosition(rb2d.transform.position + tempVect);
    }

}
