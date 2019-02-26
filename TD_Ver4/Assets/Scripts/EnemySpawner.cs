using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{

    public Transform enemyPrefab;
    public Transform spawnPoint;
    public Transform enemyPrefab2;
    public Transform enemyPrefab3;

    private float timeBetweenWaves = 5f;
    private float countdown = 1f;

    // Henter alle linjer ifra et tekstdokument (wavelist.txt)
    private string[] allLines = File.ReadAllLines("Assets\\Scripts\\Resources\\wavelist.txt");
    private string line = string.Empty;


    //public Text waveCountDownText;

    private int waveIndex = 0;
    
    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0f) {
            // Går ut av løkken hvis wavelist.txt ikke har flere linjer
            if (waveIndex >= allLines.Length) {
                return;
            }

            StartCoroutine(SpawnWave()); // Uses StartCoroutine because of the IEnumerator method
            countdown = timeBetweenWaves;
            timeBetweenWaves++;
        }

        
        countdown -= Time.deltaTime;
        //waveCountDownText.text = "Wave: " + waveIndex.ToString() + "/" + allLines.Length.ToString();
    }

    // IEnumerator allows pausing of the subroutine "SpawnWave()"
    IEnumerator SpawnWave() {
        waveIndex++;
            
            
        line = allLines[waveIndex-1];

        // Splitter line opp i flere int
        int[] enemies = line.Split(',').Select(int.Parse).ToArray();

        // Går gjennom int array som velger fiender
        for (int i = 0; i < enemies.Length; i++){
            if(enemies[i] == 0) {
                SpawnEnemy();
                yield return new WaitForSeconds(0.5f);
            }

            if(enemies[i] == 1) {
                SpawnBeefy();
                yield return new WaitForSeconds(0.5f);
            }

            if (enemies[i] == 3)
            {
                SpawnSpeedster();
                yield return new WaitForSeconds(0.5f);
            }

        }
}


    void SpawnBeefy() {
        Instantiate(enemyPrefab2, spawnPoint.position, spawnPoint.rotation);
    }

    void SpawnEnemy() {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    void SpawnSpeedster() {
        Instantiate(enemyPrefab3, spawnPoint.position, spawnPoint.rotation);
    }
}
