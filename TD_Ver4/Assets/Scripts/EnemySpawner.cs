using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{

    public Transform enemyPrefab;
    public Transform spawnPoint;
    public Transform enemyPrefab2;

    private float timeBetweenWaves = 5f;
    private float countdown = 1f;

    public Text waveCountDownText;

    private int waveIndex = 0;
    
    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0f) {
            StartCoroutine(SpawnWave()); // Uses StartCoroutine because of the IEnumerator method
            countdown = timeBetweenWaves;
            timeBetweenWaves++;
        }

        
        countdown -= Time.deltaTime;
        waveCountDownText.text = "WaveCountdown: " + Mathf.Round(countdown + 1).ToString();
    }

// IEnumerator allows pausing of the subroutine "SpawnWave()"
IEnumerator SpawnWave() {
        waveIndex++;
        //Debug.Log("Wave Incoming!");
        for (int i = 0; i < waveIndex; i++) {
            SpawnEnemy();
        }
        // Setter randome verdier inn i array
        float[] enemyList = new float[4];
        for (int i = 0; i < enemyList.Length; i++) {
            enemyList[i] = Random.Range(0.0f, 1.0f);
        }
        
        for (int i = 0; i < enemyList.Length; i++) {
            if (enemyList[i] < 0.5f)
            {
                SpawnEnemy();
            }
            else if(enemyList[i] > 0.5f)
            {
                SpawnBeefy();
            }
//>>>>>>> master
            yield return new WaitForSeconds(0.5f);
        }

    }


    void SpawnBeefy() {
        Instantiate(enemyPrefab2, spawnPoint.position, spawnPoint.rotation);
    }

    void SpawnEnemy() {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
