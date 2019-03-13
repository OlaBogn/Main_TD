using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileContainer : MonoBehaviour
{

    // Oppretter array som holder på alle turretTiles
    public static Transform[] tiles;
    public static bool[] hasBuilding;

    void Awake()
    {
        tiles = new Transform[transform.childCount];
        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i] = transform.GetChild(i);
        }
        hasBuilding = new bool[tiles.Length];

    }

}
