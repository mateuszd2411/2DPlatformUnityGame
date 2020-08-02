using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FlyEnemyMove : MonoBehaviour
{
    private PlayerController thePlayer;

    public float moveSpeed;

    public float playerRange;

    public LayerMask palyerLayer;

    public bool playerInRange;
    public bool facingAway;

    public bool followOnLookAway;

    public AudioSource buzzySoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {

        playerInRange = Physics2D.OverlapCircle(transform.position, playerRange, palyerLayer);

        if(!followOnLookAway)
        {
            if (playerInRange)
            {
                transform.position = Vector3.MoveTowards(transform.position,
                thePlayer.transform.position, moveSpeed * Time.deltaTime);
                return;
            }
        }

        if((thePlayer.transform.position.x < transform.position.x 
            && thePlayer.transform.localScale.x < 0) ||
            (thePlayer.transform.position.x > transform.position.x
            && thePlayer.transform.localScale.x > 0))
        {
            facingAway = true;
        }
        else
        {
            facingAway = false;
        }

        if (playerInRange && facingAway)
        {
            buzzySoundEffect.Stop();
            transform.position = Vector3.MoveTowards(transform.position,
            thePlayer.transform.position, moveSpeed * Time.deltaTime);
        }else
        {
            buzzySoundEffect.Play();
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, playerRange);
    }

}
