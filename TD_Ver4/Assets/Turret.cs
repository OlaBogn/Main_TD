using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    private Transform target;
    public float range = 15f;

    public string enemyTag = "Enemy";

    public Transform PartToRotate;
    public float turnSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.3f); //Checks target at start and every 0.5s
    }

    void UpdateTarget() 
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies) {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy <= shortestDistance) {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range) {
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

        Vector3 dir = target.position - transform.position; // vector pointing to enemy
        Quaternion lookRotation = Quaternion.LookRotation(dir); // converts dir into Quaternion

        Vector3 rotation = Quaternion.Lerp(PartToRotate.rotation, lookRotation, Time.deltaTime*turnSpeed).eulerAngles; // sets lookrotation to be in eulerAngles
        
        // Makes shure that the tower object only turns in the correct dimensions. TODO: FIX THE BLOODY THINGY!!!
        //PartToRotate.rotation = Quaternion.Euler(0f, 0f, rotation.z); // rotates PartToRotate to
        //Quaternion.Lerp() smooths transitions between angles by speedparameter "turnSpeed"
        
        PartToRotate.rotation = Quaternion.Lerp(PartToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed);

    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
