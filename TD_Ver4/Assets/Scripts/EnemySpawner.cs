﻿using System.Collections;
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
    private string[] allLines = File.ReadAllLines("Assets\\Scripts\\Resources\\wavelist.txt");
    private string line = string.Empty;
    private int waveIndex = 0;

    private void Awake() {
        UpdateWaveText();
    }

    public void SpawnNextWave() {
        if (waveIndex >= allLines.Length) {
            return;
        }
        StartCoroutine(SpawnWave());
        UpdateWaveText();
    }

    void UpdateWaveText() {
        string waveText = "Wave: " + waveIndex + "/" + allLines.Length;
        waveCounter.text = waveText;
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
    
    public void SpawnBeefy() {
        Instantiate(enemyPrefab2, spawnPoint.position, spawnPoint.rotation);
    }

    public void SpawnEnemy() {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public void SpawnSpeedster() {
        Instantiate(enemyPrefab3, spawnPoint.position, spawnPoint.rotation);
    }
}
