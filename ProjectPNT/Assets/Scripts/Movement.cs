using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    Vector2 move;
    Rigidbody2D rb;

    public float acceleration = 100;
    public float deacceleration = 50;
    public float maxSpeed = 120;

    public bool isDashButtonDown;
    public float dashUnits = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //  Trec in variabila rb componenta de tip Rigidbody2D;
        //  astfel pot accesa properties de la Rigidbody2D
    }

    void FixedUpdate()
    {
        //rb.AddForce(move * speed * Time.deltaTime);
        Move();
        rb.velocity = move * speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        //move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        //Move();
        Dash();
    }

    private void Move()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        CalculateSpeed();
        //Dash();
    }

    private void CalculateSpeed()
    {
        if ((Input.GetKey(KeyCode.UpArrow) ^ Input.GetKey(KeyCode.DownArrow))
            || (Input.GetKey(KeyCode.LeftArrow) ^ Input.GetKey(KeyCode.RightArrow)))
        {
            if (Mathf.Abs(move.x) > 0 || Mathf.Abs(move.y) > 0)
            {
                //Debug.Log(transform.position);
                speed = speed + acceleration * Time.deltaTime;
            }
            //else
            //{
            //    speed = speed - deacceleration * Time.deltaTime;
            //}
            speed = Mathf.Clamp(speed, 0, maxSpeed);
        }
        else
        {
            speed = 0;
        }
    }

    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //this.isDashButtonDown = true;
            Debug.Log("am intrat cumetre");
            rb.MovePosition(transform.position + (Vector3)move * this.dashUnits);
        }
        /*if (this.isDashButtonDown == true || Input.GetKey(KeyCode.UpArrow))
        {
            move = transform.position + (Vector3)move * this.dashUnits;
            this.isDashButtonDown = false;
        }*/
    }

}