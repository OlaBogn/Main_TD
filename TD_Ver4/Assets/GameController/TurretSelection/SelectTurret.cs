using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectTurret : MonoBehaviour
{
    private int next = 0;

    [Header("Unity setup")]
    public GameObject[] turrets; // remembers all turret prefabs
    public Text[] buttons; // collects all buttons to modify content
    public GameObject[] selectedTurrets; // shows selected turrets

    private void Awake() {
        ChangeButtonNames();
    }

    // TODO: attach prefab to TurretSelected on button clicked

    public void ChangeButtonNames() {
        int count = 0;
        foreach(GameObject turret in turrets) {
            buttons[count].text = turret.name;
            count++;
        }
    }


}
