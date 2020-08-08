using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayImageInObject : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;

    public LevelLoader levelLoader;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = FindObjectOfType<SpriteRenderer>();

        levelLoader = FindObjectOfType<LevelLoader>();

        spriteRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(levelLoader.playerInZone)
        {
            spriteRenderer.flipY = true;
        }
    }
}
