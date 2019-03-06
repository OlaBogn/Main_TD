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

    // Må bli renamet for hver turret
    public void PurchaseTurret0()
    {
        gm.GetComponent<BuildManager>().SetTurretToBuild(GameControl.control.prefabs[0]);

        //Debug.Log("Turret 0 Purchased");
       // buildManager.SetTurretToBuild(buildManager.turret0);
       // tileClick.BuildTurret(buildManager.turret0);
    }

    public void PurchaseTurret1()
    {
        gm.GetComponent<BuildManager>().SetTurretToBuild(GameControl.control.prefabs[1]);
        Debug.Log("Turret 1 Purchased");
       // buildManager.SetTurretToBuild(buildManager.anotherTurretPrefab);
    }

    public void PurchaseTurret2()
    {
        gm.GetComponent<BuildManager>().SetTurretToBuild(GameControl.control.prefabs[2]);
        Debug.Log("Turret 2 Purchased");
        // buildManager.SetTurretToBuild(buildManager.anotherTurretPrefab);
    }

    public void PurchaseTurret3()
    {
        Debug.Log("Turret 3 Purchased");
        // buildManager.SetTurretToBuild(buildManager.anotherTurretPrefab);
    }

    public void PurchaseTurret4()
    {
        Debug.Log("Turret 4 Purchased");
        // buildManager.SetTurretToBuild(buildManager.anotherTurretPrefab);
    }
}
