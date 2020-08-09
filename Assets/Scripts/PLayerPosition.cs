using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PLayerPosition : MonoBehaviour
{

    private PlayerController player;

    Text text;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Player position is: " + player.transform.position);

        

        text.text = "X: " + Math.Round( player.transform.position.x) + " Y: " + Math.Round(player.transform.position.y);
    }
}
