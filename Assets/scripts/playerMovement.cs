using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{

    private Rigidbody2D body;

    public bool grounded;
    public bool wallable;
    public bool isAimingHead;
    public bool isClimbing;

    public float jumpHeight;
    public float speed;


    public string wall_RelaPos;

    PlayerControl control;


    Vector2 controlMoveValue;
    Vector2 aimHeadValue;

    public enum PlayerStates {normal, aiming, climbing, aimClimbing}
    public PlayerStates currentPlayerStateIs;

    private void Awake()
    {
        control = new PlayerControl();

        control.inGameControl.stickMovement.performed += ctx => controlMoveValue = ctx.ReadValue<Vector2>();
        control.inGameControl.stickMovement.started += ctx => controlMoveValue = ctx.ReadValue<Vector2>();
        control.inGameControl.stickMovement.canceled += ctx => controlMoveValue = ctx.ReadValue<Vector2>();

        control.inGameControl.aimHead.performed += ctx => aimHeadValue = ctx.ReadValue<Vector2>();
        control.inGameControl.aimHead.started += ctx => aimHeadValue = ctx.ReadValue<Vector2>();
        control.inGameControl.aimHead.canceled += ctx => aimHeadValue = ctx.ReadValue<Vector2>();

        control.inGameControl.TriggerHeadThrow.performed += ctx => headThrow(ctx);
        control.inGameControl.TriggerHeadThrow.started += ctx => headThrow(ctx);
        control.inGameControl.TriggerHeadThrow.canceled += ctx => headThrow(ctx);

        control.inGameControl.jumpcling.performed += ctx => southButtonPerformed();
    }


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        control.inGameControl.Enable();
        currentPlayerStateIs = PlayerStates.normal;
    }

    void southButtonPerformed()
    {
        if (grounded == true  && wallable == false)
        {
            jump();
        }
        else if (wallable == true && currentPlayerStateIs == PlayerStates.normal)
        {
            currentPlayerStateIs = PlayerStates.climbing;
            isClimbing = true;
        }
        else if (currentPlayerStateIs == PlayerStates.climbing)
        {
            wallJump();
        }
    }
    private void jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpHeight);
    }
    private void wallJump()
    {
        body.velocity = new Vector2(controlMoveValue.x * speed, jumpHeight * 1.25f);

    }

    private void headThrow(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            isAimingHead = true;
            if (isClimbing == false)
            {
                currentPlayerStateIs = PlayerStates.aiming;

            }
            else if (isClimbing == true)
            {
                currentPlayerStateIs = PlayerStates.aimClimbing;
            }
        }
        else if (ctx.canceled)
        {
            isAimingHead = false;

            if (isClimbing == false)
            {
                currentPlayerStateIs = PlayerStates.normal;

            }
            else if (isClimbing == true)
            {
                currentPlayerStateIs = PlayerStates.climbing;
            }
        }
    }

    private void move()
    {
        if (currentPlayerStateIs == PlayerStates.normal)
        {
            if (grounded == true)
            {
                body.velocity = new Vector2(controlMoveValue.x * speed, body.velocity.y);

            }
            else if (grounded == false && currentPlayerStateIs == PlayerStates.normal)
            {
                body.velocity = new Vector2(controlMoveValue.x * speed, body.velocity.y + Mathf.Clamp(controlMoveValue.y * speed * 0.01f, -999f, 0f));

            }

        }
        else if (currentPlayerStateIs == PlayerStates.aiming)
        {
            body.velocity = new Vector2(controlMoveValue.x * speed * .25f, body.velocity.y * .25f);
        }
        

    }

    void Update()
    {
        move();
        //Debug.Log(controlMoveValue);
        //Debug.Log(isAimingHead);
        Debug.Log(aimHeadValue);
        if (currentPlayerStateIs == PlayerStates.climbing)
        {
            body.velocity = new Vector2(body.velocity.x, speed);
        }
        else if (currentPlayerStateIs == PlayerStates .aimClimbing)
        {
            body.velocity = new Vector2(body.velocity.x, speed *.25f);

        }

    }
}
