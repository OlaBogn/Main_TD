using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TurretSelect : MonoBehaviour
{
    [Header("Unity setup")]
    public GameObject[] turrets = new GameObject[10];

    [Header("Script defined refferences")]
    public GameObject[] turretButtons;
    public GameObject[] turretSelectedButtons;
    public GameObject[] infoPanels;

    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateTurretButtons();
    }
    
    void UpdateTurretButtons() {
        // child(0) = TurretButtons, child(1) = TurretsSelected, child(2) = InfoPanels
        turretButtons = new GameObject[gameObject.transform.GetChild(0).transform.childCount]; // children of TurretButtons
        infoPanels = new GameObject[gameObject.transform.GetChild(2).transform.childCount]; // children of InfoPanels
        turretSelectedButtons = new GameObject[gameObject.transform.GetChild(1).transform.childCount]; // children of TurretsSelected
        
        // Setts up turretButtons & infoPanel array references
        for (int i = 0; i < turretButtons.Length; i++) {
            turretButtons[i] = gameObject.transform.GetChild(0).transform.GetChild(i).gameObject;
            infoPanels[i] = gameObject.transform.GetChild(2).transform.GetChild(i).gameObject;
        }

        for (int i = 0; i < turrets.Length; i++) {
            turretButtons[i].transform.GetChild(0).GetComponent<Text>().text = turrets[i].name;
            turretButtons[i].transform.GetChild(1).GetComponent<Image>().sprite = turrets[i].transform.GetChild(0).transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
        }

        // Setts up turretSelectedButtons array refferences
        for (int i = 0; i < turretSelectedButtons.Length; i++) {
            turretSelectedButtons[i] = gameObject.transform.GetChild(1).transform.GetChild(i).gameObject;
        }

        for (int i = 0; i < turretSelectedButtons.Length; i++) {
            turretSelectedButtons[i].transform.GetChild(0).GetComponent<Text>().text = GameControl.control.prefabs[i].name;
            turretSelectedButtons[i].transform.GetChild(1).GetComponent<Image>().sprite = GameControl.control.prefabs[i].transform.GetChild(0).transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
        }
    }

    public void SelectTurretClicked() {
        string turretName = EventSystem.current.currentSelectedGameObject.gameObject.transform.GetChild(0).GetComponent<Text>().text;
        Debug.Log(turretName);

        //TODO: set each turret into count position
        if (turretName == turrets[0].name) {
            GameControl.control.prefabs[counter] = turrets[0];
            turretSelectedButtons[counter].transform.GetChild(0).GetComponent<Text>().text = turrets[0].name; //TODO: complete this statement on rest of alternatives;
            counter++;
        } else if (turretName == turrets[1].name) {
            GameControl.control.prefabs[counter] = turrets[1];
            counter++;
        } else if (turretName == turrets[2].name) {
            GameControl.control.prefabs[counter] = turrets[2];
            counter++;
        } else if (turretName == turrets[3].name) {
            GameControl.control.prefabs[counter] = turrets[3];
            counter++;
        } else if (turretName == turrets[4].name) {
            GameControl.control.prefabs[counter] = turrets[4];
            counter++;
        } else if (turretName == turrets[5].name) {
            GameControl.control.prefabs[counter] = turrets[5];
            counter++;
        } else if (turretName == turrets[6].name) {
            GameControl.control.prefabs[counter] = turrets[6];
            counter++;
        } else if (turretName == turrets[7].name) {
            GameControl.control.prefabs[counter] = turrets[7];
            counter++;
        } else if (turretName == turrets[8].name) {
            GameControl.control.prefabs[counter] = turrets[8];
            counter++;
        } else if (turretName == turrets[9].name) {
            GameControl.control.prefabs[counter] = turrets[9];
            counter++;
        }

    }
}
