﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpHeight;

    public Transform groundCheck;
    public float groundCheckRadious;
    public LayerMask whatIsGround;
    private bool grounded;

    private bool doubleJump;

    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadious, whatIsGround);
    }

    // Update is called once per frame
    void Update()
    {
        if (grounded)
            doubleJump = false;

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
        }

        //for double jump
        if (Input.GetKeyDown(KeyCode.Space) && !doubleJump && !grounded)
        {
            Jump();
            doubleJump = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity =
                new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity =
                new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }//void Update() END

    public void Jump()
    {
        GetComponent<Rigidbody2D>().velocity =
                new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }
}
