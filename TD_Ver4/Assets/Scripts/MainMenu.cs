﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() {
        GameControl.control.targetSceneBuildIndex += 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
    
    public void OptionsMenu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LevelSelect() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
