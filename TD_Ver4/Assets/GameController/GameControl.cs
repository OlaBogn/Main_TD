﻿using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary; // writes unreadable files for datastorage
using System.IO;

/*
 * Holds runtime-data across scenes, and saves data  to "persistentDataPath"
 */
public class GameControl : MonoBehaviour {

    public static GameControl control;
    
    public float experience;

    [Header("Unity setup")]
    public GameObject[] prefabs;
    public GameObject gameOverUI;
    private string gameOverUITag = "GameOverUI";

    public bool gameOver = false;

    void Awake() {
        if (control == null) {
            DontDestroyOnLoad(gameObject);
            control = this;
        } else if (control != this) {
            Destroy(gameObject);
        }

        Load();
        
    }

    void Start() {
        GameObject[] gos = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject go in gos) {
            if (go.CompareTag(gameOverUITag)) {
                gameOverUI = go;
            }
        }
    }

    public void setGameOver() {
        gameOver = !gameOver;
        gameOverUI.SetActive(true);
    }
    
    public void GainExperience() {
        experience += 5f;
    }

    public void Save() {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        
        data.experience = experience;

        bf.Serialize(file, data); // takes serializable "data" object and stores it in "file" location
        file.Close();
    }

    public void Load() {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);

            file.Close();
            
            experience = data.experience;
        }
    }
}

// Object being saved by GameControl
[Serializable]
class PlayerData {
    public float experience;
}