using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public int startingLives;

    private int lifeCounter;

    private Text theText;

    public GameObject gameOverScreen;

    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        theText = GetComponent<Text>();

        lifeCounter = startingLives;

        //player = FindObjectOfType<PlayerController>();

        //player.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*if(lifeCounter < 0)
        {
            gameOverScreen.SetActive(true);
        }*/

        theText.text = "x" + lifeCounter;
    }

    public void GiveLife()
    {
        lifeCounter++;
    }

    public void TakeLife()
    {
        lifeCounter--;
    }
}
