using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary; // writes unreadable files for datastorage
using System.IO;

/*
 * Holds runtime-data across scenes, and saves data  to "persistentDataPath"
 */
public class GameControl : MonoBehaviour {

    public static GameControl control;
    
    public float experience;

    public int targetSceneBuildIndex = 3;

    [Header("Unity setup")]
    public GameObject[] prefabs;
    public int[] prices;

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

        prices = new int[prefabs.Length];
        for (int i = 0; i < prefabs.Length; i++)
        {
           // prices[i] = prefabs[i].GetComponent<>().price;
        }
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

    public void UpdateTurretsList(GameObject[] gos) {
        int count = 0;
        foreach(GameObject go in gos) {
            prefabs[count] = go;
            count++;
        }
        count = 0;
    }
}

// Object being saved by GameControl
[Serializable]
class PlayerData {
    public float experience;
}
