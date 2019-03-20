﻿using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;
    public string enemyTag = "Enemy";

    public float speed = 25f;
    public float bulletDamage = 5f;

    public bool hasSplashDamage;
    public float splashRadius;

    public void Seek(Transform _target) {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame) { // if this is true the bullet "should" have hit
            HitTarget(target.gameObject);
            if (hasSplashDamage) {
                GameObject[] gos = GameObject.FindGameObjectsWithTag("Enemy");
                foreach(GameObject go in gos) {
                    Vector3 tempDir = go.transform.position - transform.position;
                    float tempDist = tempDir.magnitude;
                    if (tempDist <= splashRadius) {
                        HitTarget(go);
                    }
                }
            }
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget(GameObject go) {
        if (go.gameObject.CompareTag(enemyTag)) {
            go.gameObject.GetComponent<EnemyHealthTracker>().TakeDamage(bulletDamage);
        }
        go = null;
        return;
    }
    private void OnDrawGizmos() {
        if (hasSplashDamage) {
            Gizmos.DrawWireSphere(transform.position, splashRadius);
        }
        
    }
}
