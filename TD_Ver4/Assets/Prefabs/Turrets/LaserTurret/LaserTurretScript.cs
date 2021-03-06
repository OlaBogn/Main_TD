﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurretScript : MonoBehaviour
{
    private Transform target;
    public GameObject RangeSprite;
    private float[] stats;
    private float numUp = 3;
    private int posHolder;
    SpriteRenderer sprite;
    private string message;


    [Header("Attributes")]

    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public float damage;
    public int price = 110;
    public float level = 1;
    public int sellPrice;
    public int upCost = 50;

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
        sprite = gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<SpriteRenderer>();
        InvokeRepeating("UpdateTarget", 0f, 0.1f);
        damage = bulletPrefab.GetComponent<Bullet>().bulletDamage;
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
        yield return new WaitForSeconds(0.8f);
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

    public void ShowTurretRange()
    {
        RangeSprite.SetActive(true);
    }

    public void HideTurretRange()
    {
        RangeSprite.SetActive(false);
    }
    public void UpgradeTurret()
    {
        // Fargen spriten blir endret til
        Color gold = new Color(1f, 0.92f, 0.016f, 1f);
        Color gray = new Color(0.7f, 0.7f, 0.7f, 1f);



        if (level > numUp)
        {
            Debug.Log("Max level for tower reached!");
            message = "Tower is fully upgraded";
            MessageCall();
            return;
        }

        if (upCost > GoldHandler.gold)
        {
            Debug.Log("MORE GOLD IS REQUIRED!");
            message = "More gold is required";
            MessageCall();
            return;
        }
        level += 1;

        if (level == 2)
        {
            sprite.color = gray;

        }

        if (level == 3)
        {
            sprite.color = gold;

        }

        sellPrice = sellPrice+upCost/2;
        GoldHandler.gold = GoldHandler.gold - upCost;
        upCost += upCost/2;
        //  fireRate += 5;
        damage = damage*1.5f;
        Debug.Log("Turret Upgraded!");
        message = "Tower upgraded";
        MessageCall();

        stats[0] = range;
        stats[1] = fireRate;
        stats[2] = damage;
        stats[3] = level;

        // Sets SellButton text
        GameObject ez = GameObject.FindGameObjectWithTag("TurretStats");
        ez.SendMessage("SellPrice", sellPrice);
        ez.SendMessage("UpgradeText", upCost);

        GameObject go = GameObject.FindGameObjectWithTag("TurretStats");
        go.SendMessage("GetStats", stats);

    }




    private void OnMouseDown()
    {
        // Removes active tile click
        GameObject ree = GameObject.FindGameObjectWithTag("GameMaster");
        ree.SendMessage("SetDefault", null);

        // Removes previous RangeDisplay
        GameObject[] g = GameObject.FindGameObjectsWithTag("RangeSprite");
        foreach (GameObject z in g)
        {
            z.SendMessage("HideTurretRange", null);

        }

        // Sets SellButton text
        GameObject ez = GameObject.FindGameObjectWithTag("TurretStats");
        ez.SendMessage("SellPrice", sellPrice);
        ez.SendMessage("UpgradeText", upCost);

        // Sends stats to StatPanel
        stats = new float[4];
        stats[0] = range;
        stats[1] = fireRate;
        stats[2] = damage;
        stats[3] = level;

        GameObject go = GameObject.FindGameObjectWithTag("TurretStats");
        go.SendMessage("Setter", gameObject);
        go.SendMessage("GetStats", stats);

        ShowTurretRange();
    }
    public void SellTurret()
    {
        GameObject go = GameObject.FindGameObjectWithTag("GameMaster");
        go.SendMessage("ResetBool", posHolder);
        Destroy(gameObject);
        GoldHandler.gold += sellPrice;
        Debug.Log("Turret Sold!");
         message = "Tower sold!";
        MessageCall();
    }

    public void SetPos(int x)
    {
        posHolder = x;
    }

    private void Awake()
    {
        GameObject go = GameObject.FindGameObjectWithTag("TurretStats");
        go.SendMessage("noName", gameObject);
    }

    public void MessageCall()
    {
        GameObject go = GameObject.FindGameObjectWithTag("MessagePanel");
        go.SendMessage("Caller", message);
    }
}