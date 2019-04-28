using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    public int price;
    public GameObject[] turretBuildButtons;

    TileClick tileClick;

    private GameObject gm;

    private int gattling = 105;
    private int laser = 110;
    private int missile = 150;
    private int fire = 90;
    private int powershot = 120;
    private int railgun = 135;
    private int slime = 105;
    private int sniper = 140;
    private int nukethrower = 300;
    private int artilleri = 130;

    private void Start() {
        gm = GameObject.FindGameObjectWithTag("GameMaster");
        UpdateTurretButtons();
    }

    // Setts each button to have turret name for debugging
    public void UpdateTurretButtons() {
        for (int i = 0; i < turretBuildButtons.Length; i++) {
            GameObject temp = turretBuildButtons[i].transform.GetChild(0).gameObject;
            temp.GetComponent<Text>().text = GameControl.control.prefabs[i].name;

            if (GameControl.control.prefabs[i].name.Substring(0,3) == "Sni") {
                Text txt = turretBuildButtons[i].transform.GetChild(1).gameObject.GetComponent<Text>();
                txt.text = "Cost: " + sniper;
            } else if (GameControl.control.prefabs[i].name.Substring(0, 3) == "Gat") {
                Text txt = turretBuildButtons[i].transform.GetChild(1).gameObject.GetComponent<Text>();
                txt.text = "Cost: " + gattling;
            } else if (GameControl.control.prefabs[i].name.Substring(0, 3) == "Art") {
                Text txt = turretBuildButtons[i].transform.GetChild(1).gameObject.GetComponent<Text>();
                txt.text = "Cost: " + artilleri;
            } else if (GameControl.control.prefabs[i].name.Substring(0, 3) == "Fir") {
                Text txt = turretBuildButtons[i].transform.GetChild(1).gameObject.GetComponent<Text>();
                txt.text = "Cost: " + fire;
            } else if (GameControl.control.prefabs[i].name.Substring(0, 3) == "Las") {
                Text txt = turretBuildButtons[i].transform.GetChild(1).gameObject.GetComponent<Text>();
                txt.text = "Cost: " + laser;
            } else if (GameControl.control.prefabs[i].name.Substring(0, 3) == "Mis") {
                Text txt = turretBuildButtons[i].transform.GetChild(1).gameObject.GetComponent<Text>();
                txt.text = "Cost: " + missile;
            } else if (GameControl.control.prefabs[i].name.Substring(0, 3) == "Nuk") {
                Text txt = turretBuildButtons[i].transform.GetChild(1).gameObject.GetComponent<Text>();
                txt.text = "Cost: " + nukethrower;
            } else if (GameControl.control.prefabs[i].name.Substring(0, 3) == "Pow") {
                Text txt = turretBuildButtons[i].transform.GetChild(1).gameObject.GetComponent<Text>();
                txt.text = "Cost: " + powershot;
            } else if (GameControl.control.prefabs[i].name.Substring(0, 3) == "Rai") {
                Text txt = turretBuildButtons[i].transform.GetChild(1).gameObject.GetComponent<Text>();
                txt.text = "Cost: " + railgun;
            } else if (GameControl.control.prefabs[i].name.Substring(0, 3) == "Sli") {
                Text txt = turretBuildButtons[i].transform.GetChild(1).gameObject.GetComponent<Text>();
                txt.text = "Cost: " + slime;
            } 
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
