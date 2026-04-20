using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D body;
    public bool grounded;
    public bool walled;
    public float jumpHeight;

    PlayerControl control;


    Vector2 controlMoveValue;

    private void Awake()
    {
        control = new PlayerControl();

        control.inGameControl.stickMovement.performed += ctx => controlMoveValue = ctx.ReadValue<Vector2>();
        control.inGameControl.stickMovement.started += ctx => controlMoveValue = ctx.ReadValue<Vector2>();
        control.inGameControl.stickMovement.canceled += ctx => controlMoveValue = Vector2.zero;

    }




    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    private void jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpHeight);
        grounded = false;
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }

        if (collision.gameObject.tag == "Wall")
        {
            walled = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }

        if (collision.gameObject.tag == "Wall")
        {
            walled = false;
        }
    }

    private void move()
    {
        if (grounded == true)
        {
            body.velocity = new Vector2(controlMoveValue.x * speed, body.velocity.y);
        }
   
    }

    void Update()
    {
        move();
    }
}
