using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteMenu : MonoBehaviour
{
    public void moveToMainMenu() {
        SceneManager.LoadScene(0);
    }

    public void NextLevel() {
        int sceneMax = 0;
        sceneMax = SceneManager.sceneCountInBuildSettings;
        if (SceneManager.GetActiveScene().buildIndex >= sceneMax) {
            Debug.Log("No next level!!");
            return;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
