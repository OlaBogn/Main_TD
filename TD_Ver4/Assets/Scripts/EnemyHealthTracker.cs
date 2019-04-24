using UnityEngine;

public class EnemyHealthTracker : MonoBehaviour
{
    [Header("Attributes")]
    public float maxHealth;
    private float currentHealth;
    public int worth;

    [Header("Unity setup")]
    public GameObject robotDeath;
    public GameObject organicDeath;
    public GameObject flamingDeath;

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

    private void OnDestroy() {
        if (gameObject.name.Substring(0,3) == "Arm") {
            Instantiate(robotDeath, transform.position, Quaternion.identity);
            Instantiate(organicDeath, transform.position, Quaternion.identity);
        } else if (gameObject.name.Substring(0, 3) == "Bee") {
            Instantiate(organicDeath, transform.position, Quaternion.identity);
        } else if (gameObject.name.Substring(0, 3) == "Bos") {
            Instantiate(organicDeath, transform.position, Quaternion.identity);
        } else if (gameObject.name.Substring(0, 3) == "Ene") {
            Instantiate(organicDeath, transform.position, Quaternion.identity);
        } else if (gameObject.name.Substring(0, 3) == "Fla") {
            Instantiate(flamingDeath, transform.position, Quaternion.identity);
        } else if (gameObject.name.Substring(0, 3) == "Fly") {
            Instantiate(robotDeath, transform.position, Quaternion.identity);
        } else if (gameObject.name.Substring(0, 3) == "Gol") {
            Instantiate(organicDeath, transform.position, Quaternion.identity);
        } else if (gameObject.name.Substring(0, 3) == "Spe") {
            Instantiate(robotDeath, transform.position, Quaternion.identity);
        }
    }
}
