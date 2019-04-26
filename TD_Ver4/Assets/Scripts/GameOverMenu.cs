using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    private GameObject[] effects;

    public void moveToMainMenu() {
        DestroyAllEffects();

        SceneManager.LoadScene(0);
    }
    public void retryLevel() {
        DestroyAllEffects();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void DestroyAllEffects() {
        effects = GameObject.FindGameObjectsWithTag("Effect");

        foreach (GameObject go in effects) {
            Destroy(go);
        }
    }
    
}
