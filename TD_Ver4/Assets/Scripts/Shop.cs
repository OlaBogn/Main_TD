using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {



    TileClick tileClick;

    private GameObject gm;

    private void Start() {
        gm = GameObject.FindGameObjectWithTag("GameMaster");
    }
    // GameController.control.prefabs[];

    // TODO Legge til kode for nye prefabs!!!!   
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

    public void PurchaseTurret3()
    {
        Debug.Log("No turret yet!");
    }

    public void PurchaseTurret4()
    {
        Debug.Log("No turret yet!");
    }
}
