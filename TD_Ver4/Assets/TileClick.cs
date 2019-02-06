using UnityEngine;

public class TileClick : MonoBehaviour
{
    private string tileTag = "Tile";

    public GameObject turret;
    public Transform spawnPoint;

    void Start() {
        spawnPoint = transform;
    }

    void OnMouseDown() {
        if (this.gameObject.CompareTag(tileTag)) {
            Instantiate(turret, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
