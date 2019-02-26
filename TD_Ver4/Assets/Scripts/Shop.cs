using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    public TurretType standardTurret;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    // Må bli renamet for hver turret
    public void PurchaseStandardTurret ()
    {
        Debug.Log("Standard Turret Purchased");
    }


}
