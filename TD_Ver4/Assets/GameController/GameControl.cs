using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary; // writes unreadable files for datastorage
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    private bool timeStopped = false;

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
        data.audioLevel = gameObject.GetComponent<AudioSource>().volume;

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
            try {
                if (SceneManager.GetActiveScene().buildIndex == 2) {
                    gameObject.GetComponent<AudioSource>().volume = data.audioLevel;
                    GameObject.Find("AudioSlider").GetComponent<Slider>().value = data.audioLevel;
                }
            } catch (NullReferenceException e) {
                Debug.LogWarning(e);
            }
            
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

    public void SetAudioLevel() {
        float sliderValue = GameObject.Find("AudioSlider").GetComponent<Slider>().value;
        gameObject.GetComponent<AudioSource>().volume = sliderValue;

        Save();
    }

    public void MuteAudio() {
        gameObject.GetComponent<AudioSource>().volume = 0f;
        GameObject.Find("AudioSlider").GetComponent<Slider>().value = 0;
    }

    public void ToggleTime() {
        if (timeStopped) {
            Time.timeScale = 0f;
        } else {
            Time.timeScale = 1f;
        }
        timeStopped = !timeStopped;
    }

}

// Object being saved by GameControl
[Serializable]
class PlayerData {
    public float experience;
    public float audioLevel;
}
