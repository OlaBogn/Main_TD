using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanels : MonoBehaviour
{
    
    public GameObject[] turrets;
    Text[] list = new Text[5];

    public float[] damageValues;

    public void Awake() {
        GameObject go = null;
        
        for (int i = 0; i < turrets.Length; i++) {
            
            go = gameObject.transform.GetChild(i).gameObject; // Contains refference to panel
            for (int j = 0; j < list.Length; j++) {
                list[j] = go.transform.GetChild(j).GetComponent<Text>();
            }
            list[0].text = "Damage: ";
            list[1].text = "Fire Speed: ";
            list[2].text = "Range: ";
            list[3].text = "Price: ";
            list[4].text = "Special: ";

            
        }
    }
    
}
