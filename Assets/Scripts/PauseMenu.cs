using System;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (GameIsPaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }




     
    }
    public void LoadMenu()
    {
        //pauseMenuUI.SetActive(false);
        //Time.timeScale = 1f;
        Debug.Log("LoadMenu");
    }

    public void QuitGame()
    {
        //Application.Quit();
        Debug.Log("QuitGame");
        Application.Quit();
    }
    public void resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Debug.Log("Resume");
    }

    public void pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Debug.Log("PauseMenu");
    }
}
