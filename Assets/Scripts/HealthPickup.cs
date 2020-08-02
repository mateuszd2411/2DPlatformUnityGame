﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthToGive;

    public AudioSource pickupSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() == null)
            return;

        HealthManager.HurtPlayer(-healthToGive);

        pickupSound.Play();

        Destroy(gameObject);
    }
}
