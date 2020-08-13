using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoaderNow : MonoBehaviour
{

    public bool playerInZoneNow;

    public string levelToLoadNow;

    public string levelTagNow;

    // Start is called before the first frame update
    void Start()
    {
        playerInZoneNow = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInZoneNow)
        LoadLevelNow();
    }

    public void LoadLevelNow()
    {
        PlayerPrefs.SetInt(levelTagNow, 1);

        Application.LoadLevel(levelToLoadNow);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            playerInZoneNow = true;
        }
    }

    /*private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            playerInZoneNow = false;

        }
    }*/
}
