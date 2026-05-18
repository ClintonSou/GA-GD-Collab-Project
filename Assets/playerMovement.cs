using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{

    private Rigidbody2D body;

    public bool grounded;
    public bool wallable;
    public bool isClimbing;

    public float jumpHeight;
    public float speed;

    PlayerControl control;
    public GameObject head;


    Vector2 controlMoveValue;
    Vector2 aimHeadValue;
    public Vector2 lastStableGround;

    public enum PlayerStates {normal, aiming, climbing, aimClimbing, headOut}
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

        control.inGameControl.TriggerHeadThrowAim.performed += ctx => headThrowAimTrigger(ctx);
        control.inGameControl.TriggerHeadThrowAim.started += ctx => headThrowAimTrigger(ctx);
        control.inGameControl.TriggerHeadThrowAim.canceled += ctx => headThrowAimTrigger(ctx);

        control.inGameControl.TriggerHeadThrow.performed += ctx => headThrow();

        control.inGameControl.TriggerRebuild.performed += ctx => rebuildBody();

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
        if (currentPlayerStateIs != PlayerStates.headOut)
        {
            if (grounded == true && wallable == false)
            {
                jump();
            }
            else if (wallable == true && currentPlayerStateIs == PlayerStates.normal)
            {
                currentPlayerStateIs = PlayerStates.climbing;
                body.velocity = new Vector2 (0f, body.velocity.y);
                isClimbing = true;
            }
            else if (currentPlayerStateIs == PlayerStates.climbing)
            {
                wallJump();
            }
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

    private void headThrowAimTrigger(InputAction.CallbackContext ctx)
    {
        if (currentPlayerStateIs != PlayerStates.headOut)
        {

                if (ctx.performed || ctx.started)
                {
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
                    if (isClimbing == false && currentPlayerStateIs != PlayerStates.headOut)
                    {
                        currentPlayerStateIs = PlayerStates.normal;

                    }
                    else if (isClimbing == true && currentPlayerStateIs != PlayerStates.headOut)
                    {
                        currentPlayerStateIs = PlayerStates.climbing;
                    }
                }
                        
        }
        

    }

    private void headThrow()
    {
        if (currentPlayerStateIs == PlayerStates.aiming || currentPlayerStateIs == PlayerStates.aimClimbing)
        {
            if (grounded == true || isClimbing == true)
            {
                isClimbing = false;
                GameObject isHead = Instantiate(head, new Vector2(transform.position.x, transform.position.y + 1f), Quaternion.identity);
                isHead.GetComponent<Rigidbody2D>().velocity = new Vector2(aimHeadValue.x * -1f * 10f, aimHeadValue.y * -1f * 10f);
                currentPlayerStateIs = PlayerStates.headOut;
            }
            
        }
    }

    private void rebuildBody()
    {
        if (currentPlayerStateIs == PlayerStates.headOut)
        {
            GameObject playerHead = GameObject.FindGameObjectWithTag("head");
            transform.position = playerHead.transform.position;
            currentPlayerStateIs = PlayerStates.normal;
            playerHead.GetComponent<headScript>().lowtiergodNOW();
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
        else if (currentPlayerStateIs == PlayerStates.aiming && grounded == true)
        {
            body.velocity = new Vector2(controlMoveValue.x * speed * .25f, body.velocity.y * 0.25f);
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
            body.velocity = new Vector2(body.velocity.x, speed * 0.25f);

        }
        else if (currentPlayerStateIs == PlayerStates.headOut)
        {
            body.velocity = new Vector2(0f, body.velocity.y);
        }

        if (transform.position.y <= -6.25f)
        {
            transform.position = lastStableGround;
        }

    }
}
