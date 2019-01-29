using UnityEngine;


public class EnemyMovement : MonoBehaviour {

    public float speed = 5f;

    private Transform target;
    private int wayPointIndex = 0;
    private GameObject go;
    
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
            //DamagePlayer();
            Destroy(gameObject); // TODO: Currently destroyes tiles and enemies.... FIX!!!
            return;
        }

        wayPointIndex++;
        target = Waypoints.points[wayPointIndex];
    }
    
    
}
