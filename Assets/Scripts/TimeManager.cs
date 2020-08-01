﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public float startingTime;
    private float countingTime;

    private Text theText;

    private PauseMenu thePauseMenu;

    private HealthManager theHealth;

    //public GameObject gameOverScreen;

    //public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        countingTime = startingTime;

        theText = GetComponent<Text>();

        thePauseMenu = FindObjectOfType<PauseMenu>();

        theHealth = FindObjectOfType<HealthManager>();

        //player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (thePauseMenu.isPaused)
            return;

        countingTime -= Time.deltaTime;

        if(countingTime <= 0)
        {
            //gameOverScreen.SetActive(true);
            //player.gameObject.SetActive(false);

            theHealth.KillPlayer();
        }

        theText.text = "" + Math.Round(countingTime);
    }

    public void ResetTime()
    {
        countingTime = startingTime;
    }

}
