using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    public float range = 15f;

    public string enemyTag = "Enemy";
    private GameObject nearestEnemy;

    public Transform PartToRotate;
    public float turnSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.1f); //Checks target at start and every 0.5s
    }

    void UpdateTarget() 
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        nearestEnemy = null;
        
        foreach (GameObject enemy in enemies) {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy <= shortestDistance) {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)  {
            target = nearestEnemy.transform;
        } else {
            target = null;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) 
            return; //if turret doesnt have a target cancel update

        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * turnSpeed);
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
