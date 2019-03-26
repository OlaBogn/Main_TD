using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCompleteUIPanel : MonoBehaviour
{
    public void moveToMainMenu() {
        SceneManager.LoadScene(0);
    }
}
