using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelWaveList : MonoBehaviour
{
    private string[] wavesList = null;

    public static string[] GetWaveList() {
        string[] wavesList = {
            "3,3,3,3,3,3",
            "0,0,0,0",
            "0,0,0,1",
            "0,0,1,1",
            "0,1,1,1",
            "1,1,1,1",
            "3,3,3,3,3,3"
        };
        return wavesList;
    }
}
