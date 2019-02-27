using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelWaveList : MonoBehaviour
{
    
    public static string[] GetWaveList() {
        string[] x = {
            "3,3,3,3,3,3",
            "0,0,0,0",
            "0,0,0,1",
            "0,0,1,1",
            "0,1,1,1",
            "1,1,1,1",
            "3,3,3,3,3,3"
        };
        return x;


    }
}
