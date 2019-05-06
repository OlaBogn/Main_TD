using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{
    
    [Header("Unity SetUp")]
    public Transform spawnPoint;

    public GameObject[] enemyPrefabs;
    public Text waveCounter;

    // Henter alle linjer ifra et tekstdokument (wavelist.txt)
    private string[] allLines = GetWaveList(0);
    private string line = string.Empty;
    private int waveIndex = 0;

    public bool cr_running = false;

    private void Awake() {
        UpdateWaveText();
    }

    private void Start() {
        SendMessage("SetWaveCount", allLines.Length);
        InvokeRepeating("UpdateSpawnWaveButton", 0f, 0.1f);
    }

    public void SpawnNextWave() {
        
        if (cr_running) {
            return;
        }
        if (waveIndex >= allLines.Length) {
            return;
        }
        StartCoroutine(SpawnWave());
        UpdateWaveText();
        SendMessage("SetProgressCheckActive", null);
        SendMessage("UpdateWaveIndex", waveIndex);
    }

    void UpdateWaveText() {
        string waveText = "Wave: " + waveIndex + "/" + allLines.Length;
        waveCounter.text = waveText;
    }

    // IEnumerator allows pausing of the subroutine "SpawnWave()"
    IEnumerator SpawnWave() {
        cr_running = true;
        waveIndex++;
        line = allLines[waveIndex-1];

        // Splitter line opp i flere int
        int[] enemies = line.Split(',').Select(int.Parse).ToArray();

        // Går gjennom int array som velger fiender
        for (int i = 0; i < enemies.Length; i++){

            if (enemies[i] == 0) {
                SpawnEnemy(0); // speedster
                yield return new WaitForSeconds(0.3f);
            } else if (enemies[i] == 1) {
                SpawnEnemy(1); // enemy
                yield return new WaitForSeconds(1.0f);
            } else if (enemies[i] == 2) {
                SpawnEnemy(2); // beefy
                yield return new WaitForSeconds(1.5f);
            } else if (enemies[i] == 3) {
                SpawnEnemy(3); // flaming
                yield return new WaitForSeconds(1.0f);
            } else if (enemies[i] == 4) {
                SpawnEnemy(4); // flying
                yield return new WaitForSeconds(1.0f);
            } else if (enemies[i] == 5) {
                SpawnEnemy(5); // armored
                yield return new WaitForSeconds(1.0f);
            } else if (enemies[i] == 6) {
                SpawnEnemy(6); // Gold_enemy
                yield return new WaitForSeconds(1.0f);
            } else if (enemies[i] == 7) {
                SpawnEnemy(7); // Boss
                yield return new WaitForSeconds(1.0f);
            }

            
        }
        cr_running = false;
    }

    public void SpawnEnemy(int n) {
        Instantiate(enemyPrefabs[n], spawnPoint.position, spawnPoint.rotation);
    }
    
    public static string[] GetWaveList(int n) {
        if (n == 0) {
            string[] wavesList = {
                "1,1,1,1,1,1,1,1,1,1,1,1,1",
                "1,1,0,6,1,1,0,1,1,0,1,1,0,1,1,0,1,1,0",
                "1,0,2,1,0,2,1,0,2,1,0,2,1,0,2,1,0,2",
                "3,0,2,1,0,2,1,0,2,3,0,2,1,0,2,3,0,2",
                "3,4,2,1,0,2,1,4,2,3,0,6,2,1,4,2,3,0,2",
                "3,4,2,1,5,2,1,4,2,3,5,2,1,4,2,3,5,2",
                "3,4,2,5,5,2,5,4,2,3,5,2,5,4,2,3,5,2,6",
                "7,0,4,0,4,0,4,0,4,0,4,0,4"
            };
            return wavesList;
        }
        return null;
    }
}
