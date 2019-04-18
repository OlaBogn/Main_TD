using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectMenu : MonoBehaviour
{
    public void StartNextLevel() {
        // Check if slots are occupied, 
        //DOESNT ALLOW "START GAME" WITHOUT ALL SLOTS FILLED! 
        if (!CheckOccupiedSlots()) {
            Debug.LogWarning("Not all slots are filled!");
            return;
        }

        if (GameControl.control.targetSceneBuildIndex == 3) {
            SceneManager.LoadScene(GameControl.control.targetSceneBuildIndex + 1);
            return;
        }

        SceneManager.LoadScene(GameControl.control.targetSceneBuildIndex);

    }

    public void ReturnToMainMenu() {
        SceneManager.LoadScene(0);
    }

    bool CheckOccupiedSlots() {
        for (int i = 0; i < GameControl.control.prefabs.Length; i++) {
            if (gameObject.transform.GetChild(1).GetChild(i).GetChild(0).GetComponent<Text>().text == "Empty") {
                return false;
            }
        }
        
        return true;
    }
}
