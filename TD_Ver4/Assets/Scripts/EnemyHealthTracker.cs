using UnityEngine;

public class EnemyHealthTracker : MonoBehaviour
{
    [Header("Attributes")]
    public float maxHealth;
    private float currentHealth;
    public int worth;

    private GameObject gameMaster;

    void Start() {
        gameMaster = GameObject.Find("GameMaster");
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
        // Deathtypes: 0 = organicDeath01, 1 = OrganicDeath02, 2 = RobotDeath, 3 = Flaming
        
        var manager = gameMaster.GetComponent<EffectsManager>();
        
        if (gameObject.name.Substring(0,3) == "Arm") {
            manager.SpawnDeathEffect(2, transform);
            manager.SpawnDeathEffect(1, transform);
        } else if (gameObject.name.Substring(0, 3) == "Bee") {
            manager.SpawnDeathEffect(0, transform);
        } else if (gameObject.name.Substring(0, 3) == "Bos") {
            manager.SpawnDeathEffect(1, transform);
        } else if (gameObject.name.Substring(0, 3) == "Ene") {
            manager.SpawnDeathEffect(1, transform);
        } else if (gameObject.name.Substring(0, 3) == "Fla") {
            manager.SpawnDeathEffect(3, transform);
        } else if (gameObject.name.Substring(0, 3) == "Fly") {
            manager.SpawnDeathEffect(2, transform);
        } else if (gameObject.name.Substring(0, 3) == "Gol") {
            manager.SpawnDeathEffect(1, transform);
        } else if (gameObject.name.Substring(0, 3) == "Spe") {
            manager.SpawnDeathEffect(2, transform);
        }
    }
}
