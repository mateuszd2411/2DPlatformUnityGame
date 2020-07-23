using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject currentCheckpoit;

    private PlayerController player;

    public GameObject deathPaticle;
    public GameObject respawnPaticle;

    public float respawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }

    //wait fo respawn to diplay death particle
    public IEnumerator RespawnPlayerCo()
    {
        //paritcle
        Instantiate(deathPaticle, player.transform.position, player.transform.rotation);

        //after dead don't move
        player.enabled = false;
        player.gameObject.GetComponent<Renderer>().enabled = false;
        //stop camera after player dead
        player.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        Debug.Log("Player Respawn");

        yield return new WaitForSecondsRealtime(respawnDelay);

        player.transform.position = currentCheckpoit.transform.position;

        //after dead don't move
        player.enabled = true;
        player.gameObject.GetComponent<Renderer>().enabled = true;


        //paritcle
        Instantiate(respawnPaticle, currentCheckpoit.transform.position, currentCheckpoit.transform.rotation);

    }

}
