using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealthTracker : MonoBehaviour
{
    public int playerHealth = 10;

    public Text healthCounter;
    private float textUpdateFrequency = 0.2f;

    private float distanceToTarget;

    public string enemyTag = "Enemy";
    GameObject[] enemies;
    private GameObject nearestEnemy;



    void Start() {
        InvokeRepeating("UpdateHealth", 0f, textUpdateFrequency);
    }
    
    void Update()
    {
        if (nearestEnemy == null)
            return;
        
        distanceToTarget = Vector3.Distance(transform.position, nearestEnemy.transform.position);
        if (distanceToTarget <= 1f) {
            DamagePlayer();
        }
    }

    void DamagePlayer() {
        playerHealth--;
    }

    // Updates the playerhealth as often as textUpdateFrequency ticks down
    void UpdateHealth() {
        float shortestDistance = Mathf.Infinity;
        nearestEnemy = null;

        foreach (GameObject enemy in enemies) {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy <= shortestDistance) {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
                distanceToTarget = shortestDistance;
            }
        }

        healthCounter.text = "Health: " + playerHealth.ToString();
        enemies = GameObject.FindGameObjectsWithTag(enemyTag);
    }
    
}
