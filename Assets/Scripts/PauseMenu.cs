using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public string levelSelected;

    public string mainMenu;

    public bool isPaused;

    public GameObject pauseMenuCanvas;

    // Update is called once per frame
    void Update()
    {
        if(isPaused)
        {
            pauseMenuCanvas.SetActive(true);
        }
        else
        {
            pauseMenuCanvas.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
    }

    public void Resuume()
    {
        isPaused = false;
    }

    public void LevelSelected()
    {
        Application.LoadLevel(levelSelected);
    }

    public void Quit()
    {
        Application.LoadLevel(mainMenu);
    }
    
}
