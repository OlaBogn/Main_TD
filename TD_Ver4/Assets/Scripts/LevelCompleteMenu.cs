using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteMenu : MonoBehaviour
{
    private GameObject[] effects;

    public void moveToMainMenu() {
        DestroyAllEffects();

        SceneManager.LoadScene(0);
    }

    public void NextLevel() {
        DestroyAllEffects();

        int sceneMax = 0;
        sceneMax = SceneManager.sceneCountInBuildSettings;
        if (SceneManager.GetActiveScene().buildIndex >= sceneMax - 2) {

            SceneManager.LoadScene(sceneMax - 1);
            
        }

        GameControl.control.targetSceneBuildIndex += 1;
        SceneManager.LoadScene(3);
    }

    private void DestroyAllEffects() {
        effects = GameObject.FindGameObjectsWithTag("Effect");

        foreach(GameObject go in effects) {
            Destroy(go);
        }
    }
}
