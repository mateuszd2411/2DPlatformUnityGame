using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public bool playerInZone;

    public string levelToLoad;

    public string levelTag;

    public SpriteRenderer spriteJumpPress;

    // Start is called before the first frame update
    void Start()
    {
        playerInZone = false;
        spriteJumpPress.enabled = false;

        spriteJumpPress = FindObjectOfType<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Jump") > 0.5f && playerInZone)
        {
            //Application.LoadLevel(levelToLoad);
            LoadLevel();
        }
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
            spriteJumpPress.enabled = true;
        }
    }

    private void OnTriggerExit2D (Collider2D other)
    {
        if (other.name == "Player")
        {
            playerInZone = false;
            spriteJumpPress.enabled = false;
        }
    }
}
