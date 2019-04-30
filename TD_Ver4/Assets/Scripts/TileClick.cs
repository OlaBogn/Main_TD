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

        // Clears Turret Panel
        GameObject go = GameObject.FindGameObjectWithTag("TurretStats");
        go.SendMessage("ClearStats", null);

        // Clears Turret Range
        GameObject[] g = GameObject.FindGameObjectsWithTag("RangeSprite");

        if (g.Length == 0)
        {
            return;
        }
        foreach (GameObject z in g)
        {
            try {
                z.SendMessage("HideTurretRange", null);
            } catch (System.Exception e) {
                Debug.Log("Cant send message: " + e);
            }
            

        }
    }
}
