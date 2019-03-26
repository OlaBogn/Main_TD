using System.Collections;
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
    
   
    // Setter turret som skal bygges og sjekker om det finnes turret på nåværende node
    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
        if(HasTurret() == true)
        {
            return;
        }
        BuildTurret();
    }
    
    // Metode som bygger turret på nåværende node
    public void BuildTurret() {
        Vector3 buildOffset = new Vector3(0, 0, -1);
        Instantiate(turretToBuild, current.transform.position + buildOffset, Quaternion.identity);
    }

}