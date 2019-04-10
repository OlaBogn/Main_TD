using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanels : MonoBehaviour
{

    public GameObject[] turrets;
    
    public void Awake() {
        GameObject go = null;
        Text[] list = new Text[5];
        
        for (int i = 0; i < turrets.Length; i++) {
            go = gameObject.transform.GetChild(i).gameObject; // Contains refference to panel
            for (int j = 0; j < list.Length; j++) {
                list[j] = go.transform.GetChild(j).GetComponent<Text>();
            }
            list[0].text = "Damage: ";
            list[1].text = "Fire Speed: ";
            list[2].text = "Range: ";
            list[3].text = "Price: ";
            list[4].text = "UpgradeCost: ";

            list[0].text = list[0].text + "Value";
            list[1].text = list[1].text + "Value";
            list[2].text = list[2].text + "Value";
            list[3].text = list[3].text + "Value";
            list[4].text = list[4].text + "Value";
            // TODO: Get values from turretprefabs instead of "Value"
        }
    }
    
}
