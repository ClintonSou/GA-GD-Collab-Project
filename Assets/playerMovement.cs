using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D body;
    public bool grounded;
    public bool walled;
    public float jumpHeight;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    private void jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpHeight);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }

        if (collision.gameObject.tag == "Wall")
        {
            walled = true;
        }

        if (collision.gameObject.tag != "Wall")
        {
            walled = false;
        }
    }


    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (walled == true)
        {
            body.velocity = new Vector2(body.velocity.x, verticalInput * 10);
        }

        if (walled == false)
        {
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        }
        

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            jump();
        }
    }
}
