using UnityEngine;

public class TileClick : MonoBehaviour
{
    private string tileTag = "Tile";
    private Sprite active;
    private Sprite standard;

    public GameObject turret;
    public Transform spawnPoint;

    BuildManager buildManager;

    private bool hasTurret = false;

    void Start() {
        spawnPoint = transform;
        buildManager = BuildManager.instance;
    }

    public bool HasTurret() {
        if (this.gameObject.CompareTag(tileTag) && hasTurret == false){ 
            return false;
        }
        return true;    
    }


    void OnMouseDown() {
        // this.GetComponent<SpriteRenderer>().sprite = active;
        if (this.gameObject.CompareTag(tileTag) && hasTurret == false)
        {
            Instantiate(turret, spawnPoint.position, spawnPoint.rotation);
            hasTurret = true;

            // Debug.Log("IsPressed");
            /* if (HasTurret())
             {
                 GameObject turretToBuild = buildManager.GetTurretToBuild();
                 turret = (GameObject)Instantiate(turretToBuild, spawnPoint.position, spawnPoint.rotation);
                 hasTurret = true;
             }
             else
                 return;  */
        }
    }
}
