using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTest : MonoBehaviour
{
    private void OnGUI() {
        
        if (GUI.Button(new Rect(10, 260, 100, 30), "Save")) {
            GameControl.control.Save();
        }
        if (GUI.Button(new Rect(10, 300, 100, 30), "Load")) {
            GameControl.control.Load();
        }
    }
}
