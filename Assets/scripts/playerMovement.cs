using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D body;
    public bool grounded;
    public bool wallable;
    public float jumpHeight;

    public string wall_RelaPos;

    PlayerControl control;


    Vector2 controlMoveValue;
    Vector2 aimHeadValue;

    private void Awake()
    {
        control = new PlayerControl();

        control.inGameControl.stickMovement.performed += ctx => controlMoveValue = ctx.ReadValue<Vector2>();
        control.inGameControl.stickMovement.started += ctx => controlMoveValue = ctx.ReadValue<Vector2>();
        control.inGameControl.stickMovement.canceled += ctx => controlMoveValue = ctx.ReadValue<Vector2>();

        control.inGameControl.aimHead.performed += ctx => aimHeadValue = ctx.ReadValue<Vector2>();
        control.inGameControl.aimHead.started += ctx => aimHeadValue = ctx.ReadValue<Vector2>();
        control.inGameControl.aimHead.canceled += ctx => aimHeadValue = ctx.ReadValue<Vector2>();

        control.inGameControl.TriggerHeadThrow.performed += ctx => headThrow();

        control.inGameControl.TriggerRebuild.performed += ctx => headThrow();

        control.inGameControl.jumpcling.performed += ctx => southButtonPerformed();
    }


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        control.inGameControl.Enable();
    }

    void southButtonPerformed()
    {
        if (grounded == true  && wallable == false)
        {
            jump();
        }
        else if (wallable == true)
        {
            Debug.Log("clingToWall");
        }
    }
    private void jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpHeight);
    }

    private void headThrow()
    {
        Debug.Log("headthrow");
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
        Debug.Log(controlMoveValue);
    }
}
