using UnityEngine;


public class EnemyMovement : MonoBehaviour {

    public float speed = 5f;

    private Transform target;
    private int wayPointIndex = 0;
    public GameObject pivot;
    public GameObject sprite;
    
    void Start() {
        target = Waypoints.points[0];
    }
    private void Awake() {
        sprite.transform.rotation = Quaternion.Euler(0, 90, 90);
    }

    void Update() {

        // moves enemy
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f) {
            GetNextWaypoint();
        }
        
        pivot.transform.rotation = Quaternion.LookRotation(dir);
    }

    void GetNextWaypoint() {
        if (wayPointIndex >= Waypoints.points.Length - 1) {
            GameObject go = GameObject.FindGameObjectWithTag("GameMaster");

            go.SendMessage("DamagePlayer", null);

            Destroy(gameObject); 

            return;
        }

        wayPointIndex++;    
        target = Waypoints.points[wayPointIndex];
    }
    
}
