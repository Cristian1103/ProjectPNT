using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //  Variables
    //  [SerializeField] inseamna ca poti sa il vezi si in editor in Unity
    [SerializeField] private float moveSpeed;
    [SerializeField] private float runSpeed;

    //  private Vector2 moveDirection;
    private Vector2 moveDirection;

    //  O componenta a caracterului
    public Rigidbody2D rb;

    //  Update is called once per frame
    private void Update()
    {
        ProcessInputs();
    }

    //  FixedUpdate is called more times per frame
    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void ProcessInputs()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    private void MoveCharacter()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        //  TODO running
    }
}