using UnityEngine;

public class EnemyHealthTracker : MonoBehaviour
{
    [Header("Attributes")]
    public float maxHealth;
    private float currentHealth;

    void Start() {
        currentHealth = maxHealth; // Setts current health from max
    }

    void Update() {
        if (currentHealth <= 0) {
            Destroy(gameObject); // Destroys gameObject if health is 0 or less
        }    
    }

    public void TakeDamage(float DamageAmount) {
        currentHealth -= DamageAmount; // gameObject takes damage based on recieved value from projectile-hit
    }

}
