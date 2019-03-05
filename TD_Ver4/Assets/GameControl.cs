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
    public GameObject[] prefabs;

    void Awake() {
        if (control == null) {
            DontDestroyOnLoad(gameObject);
            control = this;
        } else if (control != this) {
            Destroy(gameObject);
        }

        Load();
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

        Debug.Log("Saved data to: " + Application.persistentDataPath.ToString() + "/playerInfo.dat");
    }

    public void Load() {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);

            file.Close();
            
            experience = data.experience;

            Debug.Log("Loaded data from: " + Application.persistentDataPath.ToString() + "/playerInfo.dat");
        }
    }
}

// Object being saved by GameControl
[Serializable]
class PlayerData {
    public float experience;
}
