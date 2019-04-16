using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour
{
    //GameControl.control.targetSceneBuildIndex

    public void StartGame() {
        SceneManager.LoadScene(GameControl.control.targetSceneBuildIndex);
    }

    public void MainMenu() {
        SceneManager.LoadScene(0);
    }
}
