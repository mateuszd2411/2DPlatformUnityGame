using System.Collections;
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
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            GetComponent<Rigidbody2D>().velocity =
                new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
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
    }
}
