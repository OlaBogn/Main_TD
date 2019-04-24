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
    private string message;
    
    private Transform[] tiles;
    private bool[] hasBuilding;
    private int price;
    private int holder;
    

    private int gattling = 100;
    private int laser = 110;
    private int missile = 150;
    private int fire = 90;
    private int powershot = 120;
    private int railgun = 135;
    private int slime = 115;
    private int sniper = 140;
    private int nukethrower = 200;
    private int artilleri = 130;



    private void Start()
    {
        tiles = TileContainer.tiles;
        hasBuilding = TileContainer.hasBuilding;
    }


    // Sjekk som finner ut om det er turret allerede bygget på node
    public bool HasTurret()
    {
        int counter = 0;
        try {
            foreach (Transform tile in tiles) {
                if (current.transform == tile) {
                    if (hasBuilding[counter] == false) {
                        holder = counter;
                        hasBuilding[counter] = true;
                        counter = 0;
                        return false;
                    }
                }
                counter++;
            }
        } catch (System.NullReferenceException e) {
            // TODO: FIX. Error occurs if the "Tower Buttons" are pressed before a tile is selected
            Debug.Log("NullReferenceException: " + e + ", no tile has been selected to upgrade."); 
        }
        
        Debug.Log("A turret already exists on this tile!");
        message = "A turret already exists on this tile";
        MessageCall();
        return true;
    }

    public void ResetBool(int x)
    {
        hasBuilding[x] = false;
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

    public void SetDefault()
    {
        if (current == null)
        {
            return;
        }
        else
        {
            current.GetComponent<SpriteRenderer>().sprite = standard;
            current = null;
        }
    }
    
   
    // Sets turret and checks if player has enough gold and if there is already built a turret on the node
    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
        GetPrice();
        if(current == null)
        {
            Debug.Log("No tile is selected");
            message = "No tile selected";
            MessageCall();
            return;
        }

        if (HasGold() == false){
            return;
        }

        if(HasTurret() == true)
        {
            return;
        }
        
        BuildTurret();
    }

    public bool HasGold()
    {
        if (price > GoldHandler.gold)
        {
            Debug.Log("MORE GOLD IS REQUIRED");
            message = "More gold is required";
            MessageCall();
            return false;
        }
        else
        {
            return true;
        }
    }

    // Sets the price of the current turret to be built
    // Må legge inn pris for turrets øverst i script
    public void GetPrice()
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
        } else

        if (turretToBuild.name.ToString() == "FireTurret")
        {
            price = fire;
        } else

        if (turretToBuild.name.ToString() == "Powershot")
        {
            price = powershot;
        } else

        if (turretToBuild.name.ToString() == "RailgunTurret")
        {
            price = railgun;
        } else

        if (turretToBuild.name.ToString() == "SlimeTurret")
        {
            price = slime;
        } else

        if (turretToBuild.name.ToString() == "SniperTurret")
        {
            price = sniper;
        }
        else

        if (turretToBuild.name.ToString() == "Nukethrower")
        {
            price = nukethrower;
        }

        if (turretToBuild.name.ToString() == "Artilleri Turret")
        {
            price = artilleri;
        }
    }
    
    
    // Instantiates turret on the current node
    public void BuildTurret() {
        GameObject go = GameObject.FindGameObjectWithTag("TurretStats");
        go.SendMessage("SetHolder", holder);

        Vector3 buildOffset = new Vector3(0, 0, -1);
            Instantiate(turretToBuild, current.transform.position + buildOffset, Quaternion.identity);
            GoldHandler.gold = GoldHandler.gold - price;
            SendMessage("UpdateGold", null);

        
    }

    public void MessageCall()
    {
        GameObject go = GameObject.FindGameObjectWithTag("MessagePanel");
        go.SendMessage("Caller", message);
    }

}