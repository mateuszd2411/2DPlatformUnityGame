﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    private float moveVelocity;
    public float jumpHeight;

    public Transform groundCheck;
    public float groundCheckRadious;
    public LayerMask whatIsGround;
    private bool grounded;

    private bool doubleJump;

    private Animator anim;

    public Transform firePoint;
    public GameObject bullet;

    public float shotDelay;
    private float shotDelayCount;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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

        anim.SetBool("Grounded", grounded);

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

        moveVelocity = 0f;

        if (Input.GetKey(KeyCode.D))
        {
            //GetComponent<Rigidbody2D>().velocity =
            //  new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

            moveVelocity = moveSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            // GetComponent<Rigidbody2D>().velocity =
            //   new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

            moveVelocity = -moveSpeed;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

        if (GetComponent<Rigidbody2D>().velocity.x > 0)
            transform.localScale = new Vector3(1f, 1f, 1f);

        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
            transform.localScale = new Vector3(-1f, 1f, 1f);

        //bullet fire
        if(Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            shotDelayCount = shotDelay;
        }

        if(Input.GetKey(KeyCode.E))
        {
            shotDelayCount -= Time.deltaTime;

            if(shotDelayCount <= 0)
            {
                shotDelayCount = shotDelay;
                Instantiate(bullet, firePoint.position, firePoint.rotation);
            }
        }

        //defend
        if(Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetBool("Defend", true);
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
        if(Input.GetKeyUp(KeyCode.Q))
        {
            anim.SetBool("Defend", false);
            GetComponent<BoxCollider2D>().isTrigger = true;
        }


    }//void Update() END

    public void Jump()
    {
        GetComponent<Rigidbody2D>().velocity =
                new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }
}
