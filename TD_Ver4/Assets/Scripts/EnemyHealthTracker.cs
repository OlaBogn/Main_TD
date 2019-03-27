using UnityEngine;

public class EnemyHealthTracker : MonoBehaviour
{
    [Header("Attributes")]
    public float maxHealth;
    private float currentHealth;
    public int worth;

    void Start() {
        currentHealth = maxHealth; // Sets current health from max
    }

    void Update() {
        if (currentHealth <= 0) {
            Destroy(gameObject); // Destroys gameObject if health is 0 or less
            GoldHandler.gold += worth;
        }    
    }

    public void TakeDamage(float DamageAmount) {
        currentHealth -= DamageAmount; // gameObject takes damage based on recieved value from projectile-hit
    }

}
