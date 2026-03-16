using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headThrow : MonoBehaviour
{
    Vector3 throwVector;
    Rigidbody2D _rb;
    LineRenderer _lr;
    public float throwStrength;
    public bool grounded;
    public GameObject refToPlayerBody;
    public bool attached;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _lr = GetComponent<LineRenderer>();
        _lr.material = new Material(Shader.Find("Sprites/Default"));
        attached = true;
    }

    void OnMouseDown()
    {
        CalculateThrowVector();
        SetArrow();
    }

    void OnMouseDrag()
    {
        CalculateThrowVector();
        SetArrow();
    }

    void CalculateThrowVector()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 distance = mousePos - this.transform.position;

        throwVector = distance.normalized * throwStrength;
    }

    void SetArrow()
    {
        _lr.positionCount = 2;
        _lr.SetPosition(0,Vector3.zero);
        _lr.SetPosition(1, throwVector.normalized/2);
        _lr.enabled = true;
        grounded = false;
    }

    void OnMouseUp()
    {
        RemoveArrow();
        Throw();
        attached = false;
    }

    void RemoveArrow()
    {
        _lr.enabled = false;
    }

    public void Throw()
    {
        _rb.AddForce(throwVector);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftShift) && grounded == true)
        {
            refToPlayerBody.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
            this.transform.position = new Vector2(refToPlayerBody.transform.position.x, refToPlayerBody.transform.position.y + 1);
            _rb.velocity = new Vector2 (0, 0);
            attached = true;
        }

        if (attached == true)
        {
            this.transform.position = new Vector2(refToPlayerBody.transform.position.x, refToPlayerBody.transform.position.y + 1);
        }

        if (attached == false)
        {

        }

    }
}
