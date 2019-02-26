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

    private float textUpdateFrequency = 0.2f;
    private float damageDistanceThreshold = 0.2f;

    GameObject[] enemies;
    private GameObject nearestEnemy;
    private GameObject previousEnemyCounted;
    
    void Start() {
        InvokeRepeating("UpdateHealth", 0f, textUpdateFrequency);
    }
    
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        
        float shortestDistance = Mathf.Infinity;
        nearestEnemy = null;
        foreach (GameObject enemy in enemies) {
            float distanceToEnemy = Vector3.Distance(endPosition.transform.position, enemy.transform.position);
            if (distanceToEnemy <= shortestDistance) {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (shortestDistance <= damageDistanceThreshold && nearestEnemy != previousEnemyCounted) {
            DamagePlayer();
            previousEnemyCounted = nearestEnemy; // checks previous enemy to avoid taking double damage
        }
        
    }

    void DamagePlayer() {
        playerHealth--;
    }

    // Updates the playerhealth as often as textUpdateFrequency ticks down
    void UpdateHealth() {
        healthCounter.text = "Health: " + playerHealth.ToString();
    }
    
}
