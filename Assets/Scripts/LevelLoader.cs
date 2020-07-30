using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    private bool playerInZone;

    public string levelToLoad;

    // Start is called before the first frame update
    void Start()
    {
        playerInZone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Vertical") > 0.5f && playerInZone)
        {
            Application.LoadLevel(levelToLoad);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            playerInZone = true;
        }
    }

    private void OnTriggerExit2D (Collider2D other)
    {
        if (other.name == "Player")
        {
            playerInZone = false;
        }
    }
}
