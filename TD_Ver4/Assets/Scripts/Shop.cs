using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {



    BuildManager buildManager;
    TileClick tileClick;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    // GameController.control.prefabs[];

    // Må bli renamet for hver turret
    public void PurchaseTurret0()
    {
        //Debug.Log("Turret 0 Purchased");
       // buildManager.SetTurretToBuild(buildManager.turret0);
       // tileClick.BuildTurret(buildManager.turret0);
    }

    public void PurchaseTurret1()
    {
        Debug.Log("Turret 1 Purchased");
       // buildManager.SetTurretToBuild(buildManager.anotherTurretPrefab);
    }

    public void PurchaseTurret2()
    {
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
