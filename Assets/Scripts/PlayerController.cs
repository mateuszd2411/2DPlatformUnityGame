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

        moveVelocity = moveSpeed * Input.GetAxisRaw("Horizontal");

        if(knockbackCount <= 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            if (knockFromRight)
                GetComponent<Rigidbody2D>().velocity = new Vector2(-knockback, knockback);
            if(!knockFromRight)
                GetComponent<Rigidbody2D>().velocity = new Vector2(knockback, knockback);
            knockbackCount -= Time.deltaTime;
        }
        

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

        if (GetComponent<Rigidbody2D>().velocity.x > 0)
            transform.localScale = new Vector3(1f, 1f, 1f);

        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
            transform.localScale = new Vector3(-1f, 1f, 1f);

        //bullet fire
        if(Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("OnionBombo", true);
            Instantiate(bullet, firePoint.position, firePoint.rotation);
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
                Instantiate(bullet, firePoint.position, firePoint.rotation);
            }
        }

        //defend
        if(Input.GetButtonDown("Fire2"))
        {
            anim.SetBool("Defend", true);
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
        if(Input.GetButtonUp("Fire2"))
        {
            anim.SetBool("Defend", false);
            GetComponent<BoxCollider2D>().isTrigger = false;
        }

    }//void Update() END

    public void Jump()
    {
        GetComponent<Rigidbody2D>().velocity =
                new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }
}
