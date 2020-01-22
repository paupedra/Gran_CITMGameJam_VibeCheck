﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{


    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject ResumeBut;

 
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        PauseMenuUI.SetActive(false);
        ResumeBut.SetActive(false);
        GameIsPaused = false;
    }

    void Pause()
    {

        PauseMenuUI.SetActive(true);
        ResumeBut.SetActive(true);
        GameIsPaused = true;
    }
}
