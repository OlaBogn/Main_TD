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
        if (SceneManager.GetActiveScene().buildIndex >= sceneMax - 2) {

            SceneManager.LoadScene(sceneMax - 1);
            
        }

        GameControl.control.targetSceneBuildIndex += 1;
        SceneManager.LoadScene(3);
    }
}
