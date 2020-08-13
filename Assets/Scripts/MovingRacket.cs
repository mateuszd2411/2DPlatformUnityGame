using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingRacket : MonoBehaviour
{
    public GameObject platform;

    public float moveSpeed;

    public Transform currentPoint;

    public Transform[] points;

    public int pointSelection;

    public bool playerInRacket;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        currentPoint = points[pointSelection];
    }

    // Update is called once per frame
    void Update()
    {

        if(!playerInRacket)
        {
            audioSource.enabled = false;
        }

        platform.transform.position = Vector3.MoveTowards(platform.transform.position,
            currentPoint.position, Time.deltaTime * moveSpeed);

        if (platform.transform.position == currentPoint.position)
        {
            pointSelection++;

            if (pointSelection == points.Length)
            {
                pointSelection = 0;
            }

            //currentPoint = points[pointSelection];
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            playerInRacket = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            playerInRacket = false;
        }
    }
}
