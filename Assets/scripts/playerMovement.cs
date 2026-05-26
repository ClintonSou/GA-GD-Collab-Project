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
    public float lowerLimit;


    public GameObject head;
    public GameObject playerSprite;

    public Animator animator;

    PlayerControl control;


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

        control.inGameControl.Disable();

    }


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        control.inGameControl.Disable();
        currentPlayerStateIs = PlayerStates.normal;
        StartCoroutine(startAnimation());
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
                animator.SetBool("isJumping", false);
                animator.SetBool("isWallstick", true);

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
        animator.SetBool("isJumping", true);
        animator.SetBool("isWallstick", false);

    }
    private void wallJump()
    {
        body.velocity = new Vector2(controlMoveValue.x * speed, jumpHeight * 1.25f);
        animator.SetBool("isJumping", true);
        animator.SetBool("isWallstick", false);

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
                        animator.SetBool("isAiming", true);


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
                        animator.SetBool("isWallstick", true);

                }
                animator.SetBool("isAiming", false);

                }

        }
        

    }

    private void headThrow()
    {


        if (currentPlayerStateIs == PlayerStates.aiming || currentPlayerStateIs == PlayerStates.aimClimbing)
        {
            animator.SetBool("isAiming", false);

            if (grounded == true || isClimbing == true)
            {
                isClimbing = false;
                GameObject isHead = Instantiate(head, new Vector2(transform.position.x, transform.position.y + 1f), Quaternion.identity);
                isHead.GetComponent<Rigidbody2D>().velocity = new Vector2(aimHeadValue.x * -1f * 8f, aimHeadValue.y * -1f * 8f);
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
            StartCoroutine(emergeAnimation());
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
            animator.SetBool("isJumping", false);
        }

        

    }

    void Update()
    {
        move();
        if (currentPlayerStateIs == PlayerStates.climbing)
        {
            body.velocity = new Vector2(body.velocity.x, speed);
            animator.SetBool("isWallstick", true);

        }
        else if (currentPlayerStateIs == PlayerStates .aimClimbing)
        {
            body.velocity = new Vector2(body.velocity.x, speed * 0.25f);
            animator.SetBool("isAiming", true);
            animator.SetBool("isWallstick", false);



        }
        else if (currentPlayerStateIs == PlayerStates.headOut)
        {
            body.velocity = new Vector2(0f, body.velocity.y);
            animator.SetBool("isDead", true);


        }


        if (transform.position.y <= lowerLimit)
        {
            transform.position = lastStableGround;
        }
        animator.SetFloat("xVelocity", Mathf.Abs(body.velocity.x));
        animator.SetFloat("yVelocity", body.velocity.y);

        if (body.velocity.x < 0)
        {
            transform.localScale = new Vector3 (-1f , 1f, 1f);

        }
        else if (body.velocity.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (grounded == false && currentPlayerStateIs != PlayerStates.climbing && currentPlayerStateIs != PlayerStates.aimClimbing)
        {
            animator.SetBool("isAiming", false);

        }

    }

    
    IEnumerator startAnimation()
    {
        control.inGameControl.Disable();
        animator.SetBool("isEmerging", true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("isEmerging", false);
        control.inGameControl.Enable();
    }

    IEnumerator emergeAnimation()
    {
        animator.SetBool("isDead", false);
        animator.SetBool("isEmerging", true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("isEmerging", false);

    }
}
