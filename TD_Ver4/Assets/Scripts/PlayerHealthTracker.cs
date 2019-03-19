using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealthTracker : MonoBehaviour
{
    [Header ("Unity Setup")]

    public int playerHealth = 10;
    public string enemyTag = "Enemy";
    public Text healthCounter;
    public Transform endPosition;
    public GameObject gameOverUI;

    GameObject[] gos;
    
    void FixedUpdate() {
        InvokeRepeating("UpdateHealth", 0f, 0.01f);

        gos = GameObject.FindGameObjectsWithTag(enemyTag);
        foreach (GameObject enemy in gos) {

        }
    }

    public void DamagePlayer() {
        playerHealth--;
        
        if (playerHealth <= 0) {
            UpdateHealth();
            gameOverUI.SetActive(true);
            Time.timeScale = 0f; // freezes time
        }
    }
    // Resets timescale on awake to make the retry functionality work
    void Awake() {
        Time.timeScale = 1f;
    }

    // Updates the playerhealth as often as textUpdateFrequency ticks down
    void UpdateHealth() {
        healthCounter.text = "Health: " + playerHealth.ToString();
    }
    
}
