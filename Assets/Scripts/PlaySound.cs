using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{

    public AudioSource audioSource;

    public bool playerInRange;

    public float playerRange;

    public LayerMask palyerLayer;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInRange = Physics2D.OverlapCircle(transform.position, playerRange, palyerLayer);

        if (!playerInRange)
        {
            audioSource.Play();
        }
    }
}
