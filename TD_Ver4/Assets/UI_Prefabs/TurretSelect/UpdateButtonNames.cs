using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateButtonNames : MonoBehaviour
{

    public GameObject[] btnsSelected;
    public Sprite[] turretSprites;

    private void Start() {
        for (int i = 0; i < btnsSelected.Length; i++) {
            GameObject go = btnsSelected[i].transform.GetChild(0).gameObject;
            go.GetComponent<Text>().text = GameControl.control.prefabs[i].name;
            go = btnsSelected[i].transform.GetChild(1).gameObject;
            go.GetComponent<Image>().sprite = FindSprite(GameControl.control.prefabs[i].name);
        }
    }

    public Sprite FindSprite(string name) {
        switch (name.Substring(0,3)) {
            case ("Fir"):
                return turretSprites[0];
               
            case ("Gat"):
                return turretSprites[1];
                
            case ("Las"):
                return turretSprites[2];
                
            case ("Mis"):
                return turretSprites[3];
                
            case ("Pow"):
                return turretSprites[4];
                
            case ("Rai"):
                return turretSprites[5];
                
            case ("Sli"):
                return turretSprites[6];
                
            case ("Sni"):
                return turretSprites[7];
                
            default:
                Debug.Log("Sprite not found");
                return null;

        }

    }
}
