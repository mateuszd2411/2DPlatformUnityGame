using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    private float moveVelocity;
    public float jumpHeight;

    private Rigidbody2D myRigidbody2D;

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

    public float knockback;
    public float knockbackLenght;
    public float knockbackCount; 
    public bool knockFromRight;

    //for Ladder
    public bool onLadder;
    public float climbSpeed;
    private float climbVelovity;
    private float gravityStore;

    //for Gayser
    public bool onGayser;
    private float gravityStoreForGayser;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        myRigidbody2D = GetComponent<Rigidbody2D>();
        gravityStoreForGayser = myRigidbody2D.gravityScale;
        gravityStore = myRigidbody2D.gravityScale;
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadious, whatIsGround);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Player position is: " + this.transform.position);

        if (grounded)
            doubleJump = false;

        anim.SetBool("Grounded", grounded);
#if UNITY_STANDALONE || UNITY_WEBPLAYER

        if (Input.GetButtonDown("Jump") && grounded)
        {
            Jump();
        }

        //for double jump
        if (Input.GetButtonDown("Jump") && !doubleJump && !grounded)
        {
            Jump();
            doubleJump = true;
        }

        //moveVelocity = 0f;

        //moveVelocity = moveSpeed * Input.GetAxisRaw("Horizontal");
        Move(Input.GetAxisRaw("Horizontal"));

#endif

        if(knockbackCount <= 0)
        {
            myRigidbody2D.velocity = new Vector2(moveVelocity, myRigidbody2D.velocity.y);
        }
        else
        {
            if (knockFromRight)
                myRigidbody2D.velocity = new Vector2(-knockback, knockback);
            if(!knockFromRight)
                myRigidbody2D.velocity = new Vector2(knockback, knockback);
            knockbackCount -= Time.deltaTime;
        }
        

        anim.SetFloat("Speed", Mathf.Abs(myRigidbody2D.velocity.x));

        if (myRigidbody2D.velocity.x > 0)
            transform.localScale = new Vector3(1f, 1f, 1f);

        else if (myRigidbody2D.velocity.x < 0)
            transform.localScale = new Vector3(-1f, 1f, 1f);

#if UNITY_STANDALONE || UNITY_WEBPLAYER

        //bullet fire
        if(Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("OnionBombo", true);
            //Instantiate(bullet, firePoint.position, firePoint.rotation);
            FireBullet();
            shotDelayCount = shotDelay;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            anim.SetBool("OnionBombo", false);
        }

            if (Input.GetButton("Fire1"))
        {
            shotDelayCount -= Time.deltaTime;

            if(shotDelayCount <= 0)
            {
                shotDelayCount = shotDelay;
                //Instantiate(bullet, firePoint.position, firePoint.rotation);
                FireBullet();
            }
        }

        //defend
        if(Input.GetButtonDown("Fire2"))
        {
            Defend();
        }
        if(Input.GetButtonUp("Fire2"))
        {
            ResetDefend();
            //anim.SetBool("Defend", false);
           // GetComponent<BoxCollider2D>().isTrigger = false;
        }



        //gayser
        if (onGayser)
        {
            myRigidbody2D.gravityScale = 0;
            climbVelovity = 4 * climbSpeed * Input.GetAxisRaw("Jump");

            myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, climbVelovity);
        }

        if (!onGayser)
        {
            myRigidbody2D.gravityScale = gravityStoreForGayser;
        }

        //ladder
        if (onLadder)
        {
            myRigidbody2D.gravityScale = 0;

            climbVelovity = climbSpeed * Input.GetAxisRaw("Vertical");

            myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, climbVelovity);
        }

        if (!onLadder)
        {
            myRigidbody2D.gravityScale = gravityStore;
        }

#endif

    }//void Update() END

    //Move
    public void Move(float moveInput)
    {
        moveVelocity = moveSpeed * moveInput;
    }

    public void FireBullet()
    {
        anim.SetBool("OnionBombo", true);
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

    public void FireBulletUp()
    {
        anim.SetBool("OnionBombo", false);
    }

    public void Defend()
    {
        anim.SetBool("Defend", true);
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    public void ResetDefend()
    {
        anim.SetBool("Defend", false);
        GetComponent<BoxCollider2D>().isTrigger = false;
    }

    public void DoubleJumpPlayer()
    {
        if (grounded)
        {
            myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, jumpHeight * 1.5f);
            doubleJump = true;
        }

    }

    public void Jump()
    {
        //myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, jumpHeight);

        if (grounded)
        {
            //Jump();
            myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, jumpHeight);
        }

        //for double jump
        if (!doubleJump && !grounded)
        {
            //Jump();
            myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, jumpHeight);
            doubleJump = true;
        }

    }

    public void JumpOnGayser()
    {
        if (onGayser)
        {
            myRigidbody2D.gravityScale = 0;
            climbVelovity = 4 * climbSpeed;

            myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, climbVelovity);
        }

        if (!onGayser)
        {
            myRigidbody2D.gravityScale = gravityStoreForGayser;
        }
    }

    public void UpOnRope()
    {
        if (onLadder)
        {
            myRigidbody2D.gravityScale = 0;

            climbVelovity = climbSpeed * 0.5f;

            myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, climbVelovity);
        }

        if (!onLadder)
        {
            myRigidbody2D.gravityScale = gravityStore;
        }
    }

    //for Moving Platform
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.tag == "MovingPlatform")
        {
            transform.parent = other.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }

}
