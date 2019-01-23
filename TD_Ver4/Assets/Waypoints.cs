using UnityEngine;

public class Waypoints : MonoBehaviour
{

    public static Transform[] points;

    // Legger alle "waypoint-objekter" under et Transform Array kalt "points" 
    private void Awake()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
