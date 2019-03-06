﻿using UnityEngine;

public class TileClick : MonoBehaviour
{
    private string tileTag = "Tile";

    private GameObject gm;

    public GameObject turret;
    public Transform spawnPoint;


    private bool hasTurret = false;
    

    void Start() {
        spawnPoint = transform;
    }

    public bool HasTurret() {
        // Går inn i HasTurret()
        if (this.gameObject.CompareTag(tileTag) && hasTurret == false){ 
            return false;
        }
        return true;    
    }



    public void BuildTurret(GameObject turret)
    {
        if (HasTurret())
        {
            //GameObject turretToBuild = buildManager.GetTurretToBuild();
           // turret = (GameObject)Instantiate(turretToBuild, spawnPoint.position, spawnPoint.rotation);
            hasTurret = true;
            Debug.Log("Kommer inn i BuildTurret");
        }
        else
            return;
    }

    void OnMouseDown() {

        //gm.BuildManager.SetCurrent(gameObject);

        gm = GameObject.FindGameObjectWithTag("GameMaster");
        if (gm == null) {
            return;
        }
        gm.GetComponent<BuildManager>().SendMessage("SetCurrent", gameObject);



    }
}
