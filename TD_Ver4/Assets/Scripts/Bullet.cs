﻿using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;
    public string enemyTag = "Enemy";

    public float speed = 25f;
    public float bulletDamage = 5f;

    public bool hasSplashDamage = false;
    public float splashRadius;
    
    private GameObject gameMaster;

    private bool hasHit = false;

    private bool isDestroyed = false;

    public void Seek(Transform _target) {
        target = _target;
    }

    private void Start() {
        gameMaster = GameObject.Find("GameMaster");
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) {
            isDestroyed = true;
            LateUpdate();
            Destroy(gameObject);
            return;
        }

        if (hasHit) {
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        
        if (dir.magnitude <= distanceThisFrame && !hasHit) { // if this is true the bullet "should" have hit
            HitTarget(target.gameObject);
            hasHit = true;
            if (hasSplashDamage) {
                GameObject[] gos = GameObject.FindGameObjectsWithTag("Enemy");
                foreach(GameObject go in gos) {
                    Vector3 tempDir = go.transform.position - transform.position;
                    float tempDist = tempDir.magnitude;
                    if (tempDist <= splashRadius && go.gameObject != target.gameObject) {
                        HitTarget(go);
                    }
                }
            }
            target = null;
            return;
        }

        if (gameObject.name.Substring(0, 1) == "M") {
            transform.rotation = Quaternion.LookRotation(dir, new Vector3(0f, 0f, -10f));
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget(GameObject go) {
        if (go.gameObject.CompareTag(enemyTag)) {
            go.SendMessage("TakeDamage", bulletDamage);
        }
        go = null;
        return;
    }

    private void LateUpdate() {
        if (isDestroyed) {
            var manager = gameMaster.GetComponent<EffectsManager>();

            if (gameObject.name.Substring(0, 4) == "Miss") {
                manager.SpawnExplosionEffect(0, transform);
            }
            if (gameObject.name.Substring(0, 4) == "Nuke") {
                manager.SpawnExplosionEffect(1, transform);
            }
        }
    }

}
