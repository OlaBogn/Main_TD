using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{

    public Transform enemyPrefab;
    public Transform spawnPoint;

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
            yield return new WaitForSeconds(0.5f);
        }

    }

    void SpawnEnemy() {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
