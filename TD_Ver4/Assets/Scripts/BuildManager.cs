﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public GameObject turretToBuild;

    private GameObject current;
    private GameObject previous;
    public Sprite active;
    public Sprite standard;
    
    private Transform[] tiles;
    private bool[] hasBuilding;
    private int price;


    private int gattling = 100;
    private int laser = 110;
    private int missile = 150;



    private void Start()
    {
        tiles = TileContainer.tiles;
        hasBuilding = TileContainer.hasBuilding;
    }


    // Sjekk som finner ut om det er turret allerede bygget på node
    public bool HasTurret()
    {
        int counter = 0;
        foreach(Transform tile in tiles)
        {
            if (current.transform == tile)
            { 
                if(hasBuilding[counter] == false)
                {
                    hasBuilding[counter] = true;
                    counter = 0;
                    return false;
                }
            }
            counter++;
        }
        Debug.Log("A turret already exists on this tile!");
        return true;
    }

    // Endrer turretTile sprites på klikk og håndterer nåværende/forrige tileclick
    public void SetCurrent(GameObject go)
    {
        if (current == go)
            return;
        if (current == null) {
            current = go;
            current.GetComponent<SpriteRenderer>().sprite = active;
            return;
        }
        
        previous = current;
        current = go;
        

        current.GetComponent<SpriteRenderer>().sprite = active;
        previous.GetComponent<SpriteRenderer>().sprite = standard;
    }
    
   
    // Sets turret and checks if player has enough gold and if there is already built a turret on the node
    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
        if(HasTurret() == true)
        {
            return;
        }
        CanBuild();
        BuildTurret();
    }

    // Sets the price of the current turret to be built
    // Må legge inn pris for turrets øverst i script
    public void CanBuild()
    {
        if(turretToBuild.name.ToString() == "GattlingTurret")
        {
            price = gattling;
        } else

        if (turretToBuild.name.ToString() == "LaserTurret")
        {
            price = laser;
        } else

        if (turretToBuild.name.ToString() == "MissileTurret")
        {
            price = missile;
        }
    }
    
    
    // Instantiates turret on the current node
    public void BuildTurret() {
        if (price > GoldHandler.gold)
        {
            Debug.Log("MORE GOLD IS REQUIRED");
            return;
        }
        else {
            Vector3 buildOffset = new Vector3(0, 0, -1);
            Instantiate(turretToBuild, current.transform.position + buildOffset, Quaternion.identity);
            GoldHandler.gold = GoldHandler.gold - price;
            SendMessage("UpdateGold", null);
        }
    }
}