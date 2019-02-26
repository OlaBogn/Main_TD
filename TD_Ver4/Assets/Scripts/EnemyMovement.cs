using UnityEngine;


public class EnemyMovement : MonoBehaviour {

    public float speed = 5f;

    private Transform target;
    private int wayPointIndex = 0;
    public GameObject pivot;
    
    void Start() {
        target = Waypoints.points[0];
    }
    
    void Update() {
        // moves enemy
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) <= 0.1f) {
            GetNextWaypoint();
        }
        pivot.transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
    }

    void GetNextWaypoint() {
        if (wayPointIndex >= Waypoints.points.Length - 1) {
            Destroy(gameObject); 

            return;
        }

        wayPointIndex++;    
        target = Waypoints.points[wayPointIndex];
    }
    
}
