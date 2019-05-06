using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public Text playerExperience;

    private void Start() {
        playerExperience.text = GameControl.control.experience.ToString();
    }

    // This option did not end up being used
    /*
    public void ResetExperience() {
        GameControl.control.experience = 0;
        Debug.Log("Reset experience");
        playerExperience.text = GameControl.control.experience.ToString();
        GameControl.control.Save();
    }
    */

    public void BackToMainMenu() {
        SceneManager.LoadScene(0);
    }
}
