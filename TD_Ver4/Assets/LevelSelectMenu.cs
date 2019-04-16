using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectMenu : MonoBehaviour
{
    public void StartNextLevel() {
        if (GameControl.control.targetSceneBuildIndex == 3) {
            SceneManager.LoadScene(GameControl.control.targetSceneBuildIndex + 1);
            return;
        }

        SceneManager.LoadScene(GameControl.control.targetSceneBuildIndex);

    }

    public void ReturnToMainMenu() {
        SceneManager.LoadScene(0);
    }
}
