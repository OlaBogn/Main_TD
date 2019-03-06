using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    
    private GameObject current;
    private GameObject previous;
    public Sprite active;
    public Sprite standard;

    //public static BuildManager instance;

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

    private void Awake()
    { 
        
        // Sørger for at det bare er en instanse (Google Singleton instance)
        /*
         if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
        */
    }

    // Her må det skrives inn nye turret typer
   // public GameObject turret0 = GameControl.control.prefabs[0];
    //public GameObject turret1 = GameControl.control.prefabs[1];
    //public GameObject turret2 = GameControl.control.prefabs[2];
  //  public GameObject turret3 = GameControl.control.prefabs[3];
   // public GameObject turret4 = GameControl.control.prefabs[4];


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
    
   

}