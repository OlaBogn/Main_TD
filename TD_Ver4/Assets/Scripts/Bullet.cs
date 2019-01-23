using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;

    public float speed = 20f;

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

        Destroy(gameObject);

        // TODO: temporarily destroys target.gameObject TODO!
        Destroy(target.gameObject);
        return;
    }
}
