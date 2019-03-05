using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;
    public string enemyTag = "Enemy";

    public float speed = 25f;
    public float bulletDamage = 5f;

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
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget() {
        if (target.gameObject.CompareTag(enemyTag)) {
            target.gameObject.GetComponent<EnemyHealthTracker>().TakeDamage(bulletDamage);
        }
        target = null;
        return;
    }
}
