using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 1f;

    public Text waveCountdownText;

    private int waveIndex = 0;

    void Update() {
        if (countdown <= 0f) {
            // IEnumerator methods should be started this way to give it its own internal timing
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;

        waveCountdownText.text = Mathf.Round(countdown + 1).ToString();
    }

    // Spawns a new wave (subroutine)
    IEnumerator SpawnWave() {
        waveIndex++;
        //Debug.Log("Wave Incomming!");
        for (int i = 0; i < waveIndex; i++) {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

    }

    void SpawnEnemy() {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}
