﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public bool playerInZone;

    public string levelToLoad;

    public string levelTag;

    //public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        playerInZone = false;

        /*spriteRenderer = FindObjectOfType<SpriteRenderer>();

        spriteRenderer.enabled = false;*/
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") > 0.5f && playerInZone)
        {
            //Application.LoadLevel(levelToLoad);
            LoadLevel();
        }

        /*if (playerInZone)
        {
            spriteRenderer.enabled = true;
        }
        else
        {
            spriteRenderer.enabled = false;
        }*/
    }

    public void LoadLevel()
    {
        PlayerPrefs.SetInt(levelTag, 1);

        Application.LoadLevel(levelToLoad);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            playerInZone = true;
            //spriteRenderer.enabled = true;

        }
    }

    private void OnTriggerExit2D (Collider2D other)
    {
        if (other.name == "Player")
        {
            playerInZone = false;
            //spriteRenderer.enabled = false;

        }
    }
}
