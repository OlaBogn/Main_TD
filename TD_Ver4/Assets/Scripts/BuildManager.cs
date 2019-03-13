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


    // Endrer turretTile sprites på klikk og håndterer nåværende/forrige tileclick
    public void SetCurrent(GameObject go)
    {

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
    
   

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
        BuildTurret();
    }
    
    public void BuildTurret() {
        Instantiate(turretToBuild,current.transform.position, Quaternion.identity);
    }

}