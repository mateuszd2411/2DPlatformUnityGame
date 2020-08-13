using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPAtrol : MonoBehaviour
{
    public float moveSpeed;
    public bool moveRight;

    public Transform wallCheck;
    public float wallCheckRadious;
    public LayerMask whatIsWall;
    private bool hittingWall;

    private bool notAtEdge;
    public Transform edgeCheck;

    private float ySize;

    // Start is called before the first frame update
    void Start()
    {
        ySize = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadious, whatIsWall);

        notAtEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadious, whatIsWall);

        if (hittingWall || !notAtEdge)
            moveRight = !moveRight;

        if (moveRight)
        {
            //turn
            GetComponent<Transform>().localScale
                = new Vector3(-ySize, transform.localScale.y, transform.localScale.z);

            GetComponent<Rigidbody2D>().velocity
                = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            GetComponent<Transform>().localScale
                = new Vector3(ySize, transform.localScale.y, transform.localScale.z);

            GetComponent<Rigidbody2D>().velocity
                = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }
}
