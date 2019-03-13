using UnityEngine;

public class TileClick : MonoBehaviour
{

    private GameObject gm;

    public GameObject turret;
    public Transform spawnPoint;

    void Start() {
        spawnPoint = transform;
    }

    void OnMouseDown()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster");

        if (gm == null) {
            return;
        }

        gm.GetComponent<BuildManager>().SendMessage("SetCurrent", gameObject);
    }
}
