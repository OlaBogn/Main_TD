using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void moveToMainMenu() {
        SceneManager.LoadScene(0);
        GameControl.control.setGameOver();
    }
    public void retryLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameControl.control.setGameOver();
    }
}
