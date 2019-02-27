using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    private void Start()
    {
        
    }
   
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

    // Her må det skrives inn nye turret typer
    public GameObject standardTurretPrefab;
    public GameObject anotherTurretPrefab;

    // Logikk
    public GameObject turretToBuild;



    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }



    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn (TileClick node) {
       // Instantiate(turretToBuild.prefab, node.transform.position + node.positionOffset);
    }

}