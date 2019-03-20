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
    }
}
