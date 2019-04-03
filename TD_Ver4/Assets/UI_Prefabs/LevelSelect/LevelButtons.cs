using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButtons : MonoBehaviour
{
    public void Level1() {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameControl.control.targetSceneBuildIndex = 4;
        SceneManager.LoadScene(3);
    }

    public void Level2() {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        GameControl.control.targetSceneBuildIndex = 5;
        SceneManager.LoadScene(3);
    }

    public void Level3() {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        GameControl.control.targetSceneBuildIndex = 6;
        SceneManager.LoadScene(3);
    }

    public void Level4() {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
        GameControl.control.targetSceneBuildIndex = 7;
        SceneManager.LoadScene(3);
    }

    public void MainMenu() {
        SceneManager.LoadScene(0);
    }
}
