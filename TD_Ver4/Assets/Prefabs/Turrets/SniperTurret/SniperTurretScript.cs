using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperTurretScript : MonoBehaviour
{
    private Transform target;

    [Header("Attributes")]

    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public Animator animator;


    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";
    private GameObject nearestEnemy;

    public Transform PartToRotate;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.1f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy <= shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }


        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }

    }


    void Update()
    {
        /*if (GameControl.control.gameOver == true) {
            return;
        }*/
        if (target == null)
        {
            fireCountdown -= Time.deltaTime;
            //animator.SetBool("inRange", false);
            return; //if turret doesnt have a target cancel update of rotation (Still lowers fireCountdown)
        }
        else
        {

            //animator.SetBool("inRange", true);
        }

        // Rotates turret towards current target
        Vector3 dir = target.position - PartToRotate.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        PartToRotate.transform.rotation = Quaternion.Lerp(PartToRotate.transform.rotation, q, Time.deltaTime * turnSpeed); //(Lerp is used to smooth this transition)

        // Calculates rate of fire and shoots if cooldown is done
        if (fireCountdown <= 0f)
        {
            animator.SetBool("inRange", true);
            StartCoroutine(Shoot());
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0f);
        animator.SetBool("inRange", false);
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        

        if (bullet != null)
        {
            bullet.Seek(target);
        }
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
