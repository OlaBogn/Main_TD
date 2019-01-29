using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WalkingEnemy : MonoBehaviour {

    public float speed = 5f;

    private Transform target;
    private int wayPointIndex = 0;
    private GameObject go;

    public Text textObject;
    private int playerHealth = 10;

    // Start is called before the first frame update
    void Start() {
        target = Waypoints.points[0];
    }

    // Update is called once per frame
    void Update() {
        // dir = direction
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) <= 0.1f) {
            GetNextWaypoint();
        }


    }

    void GetNextWaypoint() {
        if (wayPointIndex >= Waypoints.points.Length - 1) {
            Destroy(gameObject); // TODO: Currently destroyes tiles and enemies.... FIX!!!
            DamagePlayer();
            return;
        }

        wayPointIndex++;
        target = Waypoints.points[wayPointIndex];
    }

    void DamagePlayer() {
        playerHealth--;
        textObject.text = "Health: " + (playerHealth);
    }
}
