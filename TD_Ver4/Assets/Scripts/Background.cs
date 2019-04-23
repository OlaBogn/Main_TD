using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    public void OnMouseDown()
    {
        // Clears Turret Panel
        GameObject go = GameObject.FindGameObjectWithTag("TurretStats");
        go.SendMessage("ClearStats", null);

        GameObject ree = GameObject.FindGameObjectWithTag("GameMaster");
        ree.SendMessage("SetDefault", null);

        // Clears Turret Range
        GameObject[] g = GameObject.FindGameObjectsWithTag("RangeSprite");

        if (g.Length >= 0)
        {
            return;
        }
        foreach (GameObject z in g)
        {
            z.SendMessage("HideTurretRange", null);

        }
    }
}
