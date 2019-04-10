using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{
    
    [Header("Unity SetUp")]
    public Transform spawnPoint;
    public Transform enemyPrefab;
    public Transform enemyPrefab2;
    public Transform enemyPrefab3;
    public Text waveCounter;

    // Henter alle linjer ifra et tekstdokument (wavelist.txt)
    private string[] allLines = GetWaveList(0);
    private string line = string.Empty;
    private int waveIndex = 0;

    private bool cr_running = false;

    private void Awake() {
        UpdateWaveText();
    }

    private void Start() {
        SendMessage("SetWaveCount", allLines.Length);
    }

    public void SpawnNextWave() {
        // TODO: MUST BE FIXED BEFORE TEST BUILD
        /* 
        if (cr_running) {
            return;
        }*/
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
            if(enemies[i] == 0) {
                SpawnEnemy();
                yield return new WaitForSeconds(1.0f);
            }

            if(enemies[i] == 1) {
                SpawnBeefy();
                yield return new WaitForSeconds(1.5f);
            }

            if (enemies[i] == 3)
            {
                SpawnSpeedster();
                yield return new WaitForSeconds(0.3f);
            }
        }
        cr_running = false;
    }
    
    public void SpawnBeefy() {
        Instantiate(enemyPrefab2, spawnPoint.position, spawnPoint.rotation);
    }

    public void SpawnEnemy() {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public void SpawnSpeedster() {
        Instantiate(enemyPrefab3, spawnPoint.position, spawnPoint.rotation);
    }

    public static string[] GetWaveList(int n) {
        if (n == 0) {
            string[] wavesList = {
                "3,3,3,3,3,3,3,3,3,3,3,3,3",
                "0,0,0,0",
                "0,0,0,1",
                "0,0,1,1",
                "0,1,1,1",
                "1,1,1,1",
                "3,3,3,3,3,3"
            };
            return wavesList;
        }
        return null;
    }
}
