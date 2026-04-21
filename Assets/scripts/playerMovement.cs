using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D body;
    public bool grounded;
    public bool wallable;
    public float jumpHeight;
    Scene m_Scene;
    string sceneName;
    public float movementValuethingy;
    public bool facingforward;

    //head stuff
    private Rigidbody2D headRB;
    public GameObject head;
    public float throwStrength;
    public bool attached;
    public GameObject refToPlayerBody;

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

        control.inGameControl.TriggerRebuild.performed += ctx => headRebuild();

        control.inGameControl.jumpcling.performed += ctx => southButtonPerformed();

        control.inGameControl.resetScene.performed += ctx => resetScene();

        control.inGameControl.loadScene1.performed += ctx => sceneLoad1();

        control.inGameControl.loadScene2.performed += ctx => sceneLoad2();

        control.inGameControl.loadScene3.performed += ctx => sceneLoad3();
    }


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        headRB = head.GetComponent<Rigidbody2D>();
        control.inGameControl.Enable();
        attached = true;
    }

    void southButtonPerformed()
    {
        if (grounded == true && wallable == false)
        {
            jump();
        }
        else if (wallable == true)
        {
            Debug.Log("clingToWall");
        }
    }

    private void resetScene()
    {
        this.transform.position = new Vector2(0, 0);
        attached = true;
    }
    private void sceneLoad1()
    {
        SceneManager.LoadScene("scene_1");
    }
    private void sceneLoad2()
    {
        SceneManager.LoadScene("scene_2");
    }
    private void sceneLoad3()
    {
        SceneManager.LoadScene("scene_3");
    }

    private void jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpHeight);
    }

    private void headThrow()
    {
        Debug.Log("headthrow");

        if (attached == true)
        {
            attached = false;

            if (facingforward == true)
            {
                headRB.AddForce(new Vector2(500, 50));
            }
            if (facingforward == false)
            {
                headRB.AddForce(-new Vector2(500, 50));
            }
        }
    }

    private void headRebuild()
    {
        if (attached == false)
        {
            attached = true;
            head.transform.position = new Vector2(head.transform.position.x, head.transform.position.y + 1);
            refToPlayerBody.transform.position = new Vector2(head.transform.position.x, head.transform.position.y - 1);
        }
    }

    private void move()
    {
        if (grounded == true)
        {
            body.velocity = new Vector2(controlMoveValue.x * speed, body.velocity.y);
        }
        // sydney code movement thing
        if (movementValuethingy < 0)
        {
            //refToPlayerBody.transform.localScale = new Vector3(-1, 1, 1);
            facingforward = false;
        }
        if (movementValuethingy > 0)
        {
            //refToPlayerBody.transform.localScale = new Vector3(1, 1, 1);
            facingforward = true;
        }

    }

    void Update()
    {
        move();
        Debug.Log(controlMoveValue);

        movementValuethingy = controlMoveValue.x;

        //sydney code wallable movement
        if (wallable == true && grounded == false)
        {
            body.velocity = new Vector2(controlMoveValue.x, controlMoveValue.y * speed);
        }
        //sydney code head stuff
        if (attached == true)
        {
            head.transform.position = new Vector2(refToPlayerBody.transform.position.x, refToPlayerBody.transform.position.y + 1);

            headRB.velocity = Vector3.zero;


        }

        if (attached == false)
        {

        }


    }
}
