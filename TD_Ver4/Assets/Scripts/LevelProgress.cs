using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgress : MonoBehaviour
{

    public GameObject levelCompleteUI;

    private GameObject[] enemies;
    private string enemyTag = "Enemy";
    private int waveCount;
    private int waveIndex = 0;
    private bool isActive = false;

    // checks if there are enemys on the screen and finds out if the "wave" is over
    private void FixedUpdate() {
        if (!isActive) {
            return;
        }
        enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        if (enemies.Length <= 0) {
            isActive = false;
            if (waveIndex >= waveCount) {
                levelCompleteUI.SetActive(true);
            }
        }
    }
    
    public void UpdateWaveIndex(int n) {
        waveIndex = n;
    }

    public void SetWaveCount(int n) {
        waveCount = n;
    }

    public void SetProgressCheckActive() {
        isActive = true;
    }
    
}
