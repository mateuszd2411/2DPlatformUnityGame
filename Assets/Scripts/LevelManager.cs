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

    public HealthManager healthManager;

    public PauseMenu pauseMenu;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {

        player = FindObjectOfType<PlayerController>();

        camera = FindObjectOfType<CameraController>();

        healthManager = FindObjectOfType<HealthManager>();

        pauseMenu = FindObjectOfType<PauseMenu>();

        audioSource = FindObjectOfType<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!pauseMenu.isPaused)
        {
            audioSource.mute = false;
        }

        else
        {
            audioSource.mute = true;
        }

    }

    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }

    //wait fo respawn to diplay death particle
    public IEnumerator RespawnPlayerCo()
    {
        //Stop background music
        //GetComponent<AudioSource>().Stop();

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

        //Start background music
        //GetComponent<AudioSource>().Play();

        player.transform.position = currentCheckpoit.transform.position;
        player.knockbackCount = 0;

        //after dead don't move
        player.enabled = true;
        player.gameObject.GetComponent<Renderer>().enabled = true;

        //come back to full health
        healthManager.FullHealth();
        healthManager.isDead = false;

        //camera
        camera.isFollowing = true;

        //paritcle
        Instantiate(respawnPaticle, currentCheckpoit.transform.position, currentCheckpoit.transform.rotation);

    }

}
