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

    public int pointPenaltyOnDeath;

    public float respawnDelay;

    private CameraController camera;

    private float gravityStore;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        camera = FindObjectOfType<CameraController>();
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

        //camera
        camera.isFollowing = false;
        

        // Penalty points after dead
        ScoreManager.AddPoints(-pointPenaltyOnDeath);

        Debug.Log("Player Respawn");

        yield return new WaitForSecondsRealtime(respawnDelay);
       

        player.transform.position = currentCheckpoit.transform.position;

        //after dead don't move
        player.enabled = true;
        player.gameObject.GetComponent<Renderer>().enabled = true;

        //camera
        camera.isFollowing = true;

        //paritcle
        Instantiate(respawnPaticle, currentCheckpoit.transform.position, currentCheckpoit.transform.rotation);

    }

}
