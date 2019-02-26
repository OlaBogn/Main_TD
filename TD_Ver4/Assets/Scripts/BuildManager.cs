using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    private void Awake()
    {
        // Sørger for at det bare er en instanse (Google Singleton instance)
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    // Her må det skrives inn turret typer
    public GameObject standardTurretPrefab;

    public GameObject turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
   
    public void SetTurretToBuild (GameObject turret)
    {
        turretToBuild = turret;
    }

}