using UnityEngine;

public class TileClick : MonoBehaviour
{
    private string tileTag = "Tile";

    public GameObject turret;
    public Transform spawnPoint;

    private bool hasTurret = false;

    void Start() {
        spawnPoint = transform;
    }

    void OnMouseDown() {
        if (this.gameObject.CompareTag(tileTag) && hasTurret == false) {
            Instantiate(turret, spawnPoint.position, spawnPoint.rotation);
            hasTurret = true;
        }
    }
}
