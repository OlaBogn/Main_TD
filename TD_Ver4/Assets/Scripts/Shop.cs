using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    public int price;
    public GameObject[] turretBuildButtons;

    TileClick tileClick;

    private GameObject gm;


    private void Start() {
        gm = GameObject.FindGameObjectWithTag("GameMaster");
        UpdateTurretButtons();
    }

    // Setts each button to have turret name for debugging
    public void UpdateTurretButtons() {
        for (int i = 0; i < turretBuildButtons.Length; i++) {
            GameObject temp = turretBuildButtons[i].transform.GetChild(0).gameObject;
            temp.GetComponent<Text>().text = GameControl.control.prefabs[i].name;
        }
    }

    // Metoder for hver turret knapp
    public void PurchaseTurret0()
    {
        gm.GetComponent<BuildManager>().SetTurretToBuild(GameControl.control.prefabs[0]);
    }

    public void PurchaseTurret1()
    {
        gm.GetComponent<BuildManager>().SetTurretToBuild(GameControl.control.prefabs[1]);
    }

    public void PurchaseTurret2()
    {
        gm.GetComponent<BuildManager>().SetTurretToBuild(GameControl.control.prefabs[2]);
    }

    public void PurchaseTurret3() {
        gm.GetComponent<BuildManager>().SetTurretToBuild(GameControl.control.prefabs[3]);
    }

    public void PurchaseTurret4() {
        gm.GetComponent<BuildManager>().SetTurretToBuild(GameControl.control.prefabs[4]);
    }
    
}
