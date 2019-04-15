using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TurretSelect : MonoBehaviour
{
    [Header("Unity setup")]
    public Sprite emptyPlaceholder;
    public GameObject[] turrets = new GameObject[10];

    [Header("Script defined refferences")]
    public GameObject[] turretButtons;
    public GameObject[] turretSelectedButtons;
    public GameObject[] infoPanels;

    public Sprite[] baseSprite;
    public Sprite[] topSprite;

    public bool[] selectedSlotsOccupied;
    
    // TODO: make buttons remember their contents and not update with contents if deselected
    
    void Start()
    {
        UpdateTurretButtons();
    }
    
    void UpdateTurretButtons() {
        
        // child(0) = TurretButtons, child(1) = TurretsSelected, child(2) = InfoPanels
        turretButtons = new GameObject[gameObject.transform.GetChild(0).transform.childCount]; // children of TurretButtons
        infoPanels = new GameObject[gameObject.transform.GetChild(2).transform.childCount]; // children of InfoPanels
        turretSelectedButtons = new GameObject[gameObject.transform.GetChild(1).transform.childCount]; // children of TurretsSelected

        baseSprite = new Sprite[turrets.Length];
        topSprite = new Sprite[turrets.Length];

        selectedSlotsOccupied = new bool[turretSelectedButtons.Length];

        // Setts up turretButtons & infoPanel array references
        for (int i = 0; i < turretButtons.Length; i++) {
            turretButtons[i] = gameObject.transform.GetChild(0).transform.GetChild(i).gameObject;
            infoPanels[i] = gameObject.transform.GetChild(2).transform.GetChild(i).gameObject;
        }

        // Setts up baseSprite array
        for (int i = 0; i < turrets.Length; i++) {
            baseSprite[i] = turrets[i].GetComponent<SpriteRenderer>().sprite;
        }

        // Setts up topSprite array
        for (int i = 0; i < turrets.Length; i++) {
            topSprite[i] = turrets[i].transform.GetChild(0).transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
        }

        
        // writes text- and image- elements onto turretButtons
        for (int i = 0; i < turrets.Length; i++) {
            turretButtons[i].transform.GetChild(0).GetComponent<Text>().text = turrets[i].name;
            turretButtons[i].transform.GetChild(2).GetComponent<Image>().sprite = topSprite[i];
            turretButtons[i].transform.GetChild(1).GetComponent<Image>().sprite = baseSprite[i];
        }

        // Setts up turretSelectedButtons array refferences
        for (int i = 0; i < turretSelectedButtons.Length; i++) {
            turretSelectedButtons[i] = gameObject.transform.GetChild(1).transform.GetChild(i).gameObject;
        }

        // Setts up turretSelectedButtons
        for (int i = 0; i < turretSelectedButtons.Length; i++) {
            for (int n = 0; n < turrets.Length; n++) {
                if (GameControl.control.prefabs[i].name == turrets[n].name) {
                    turretSelectedButtons[i].transform.GetChild(0).GetComponent<Text>().text = turrets[n].name;
                    turretSelectedButtons[i].transform.GetChild(1).GetComponent<Image>().sprite = baseSprite[n];
                    turretSelectedButtons[i].transform.GetChild(2).GetComponent<Image>().sprite = topSprite[n];
                }
            }
        }

        // Setts up selectedSlotsOccupied array
        for (int i = 0; i < selectedSlotsOccupied.Length; i++) {
            selectedSlotsOccupied[i] = true;
        }
    }

    public void SelectTurretClicked() {
        
        string turretName = EventSystem.current.currentSelectedGameObject.gameObject.transform.GetChild(0).GetComponent<Text>().text;
        int counter = 0;

        for (int i = 0; i < selectedSlotsOccupied.Length; i++) {
            if (selectedSlotsOccupied[i]) {
                counter++;
            } else {
                break;
            }
        }

        if (counter > selectedSlotsOccupied.Length - 1) {
            Debug.Log("All slots occupied");
            return;
        }
        
        //TODO: set each turret into count position
        if (turretName == turrets[0].name) {
            GameControl.control.prefabs[counter] = turrets[0];
            RefreshSelectedTurrets();
        } else if (turretName == turrets[1].name) {
            GameControl.control.prefabs[counter] = turrets[1];
            RefreshSelectedTurrets();
        } else if (turretName == turrets[2].name) {
            GameControl.control.prefabs[counter] = turrets[2];
            RefreshSelectedTurrets();
        } else if (turretName == turrets[3].name) {
            GameControl.control.prefabs[counter] = turrets[3];
            RefreshSelectedTurrets();
        } else if (turretName == turrets[4].name) {
            GameControl.control.prefabs[counter] = turrets[4];
            RefreshSelectedTurrets();
        } else if (turretName == turrets[5].name) {
            GameControl.control.prefabs[counter] = turrets[5];
            RefreshSelectedTurrets();
        } else if (turretName == turrets[6].name) {
            GameControl.control.prefabs[counter] = turrets[6];
            RefreshSelectedTurrets();
        } else if (turretName == turrets[7].name) {
            GameControl.control.prefabs[counter] = turrets[7];
            RefreshSelectedTurrets();
        } else if (turretName == turrets[8].name) {
            GameControl.control.prefabs[counter] = turrets[8];
            RefreshSelectedTurrets();
        } else if (turretName == turrets[9].name) {
            GameControl.control.prefabs[counter] = turrets[9];
            RefreshSelectedTurrets();
        }
    }

    void RefreshSelectedTurrets() {
        int counter = 0;
        for (int i = 0; i < turretSelectedButtons.Length; i++) {
            for (int n = 0; n < turrets.Length; n++) {
                if (GameControl.control.prefabs[i].name == turrets[n].name) {
                    turretSelectedButtons[i].transform.GetChild(0).GetComponent<Text>().text = turrets[n].name;
                    turretSelectedButtons[i].transform.GetChild(1).GetComponent<Image>().sprite = baseSprite[n];
                    turretSelectedButtons[i].transform.GetChild(2).GetComponent<Image>().sprite = topSprite[n];
                }
            }
        }
        Debug.Log("Refreshed");
        counter++;
    }

    public void ClearSelectedTurret() {
        string selectedTurretName = EventSystem.current.currentSelectedGameObject.gameObject.transform.GetChild(0).GetComponent<Text>().text;
        if (selectedTurretName == "Empty") {
            Debug.Log("Slot is empty");
            return;
        }

        GameObject temp = null;

        for (int i = 0; i < turretSelectedButtons.Length; i++) {
            if (turretSelectedButtons[i].transform.GetChild(0).GetComponent<Text>().text == selectedTurretName) {
                temp = turretSelectedButtons[i];
                selectedSlotsOccupied[i] = false;
                break;
            }
        }

        temp.transform.GetChild(0).GetComponent<Text>().text = "Empty";
        temp.transform.GetChild(1).GetComponent<Image>().sprite = emptyPlaceholder;
        temp.transform.GetChild(2).GetComponent<Image>().sprite = emptyPlaceholder;
    }
}
