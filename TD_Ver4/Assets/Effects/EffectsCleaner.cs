using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsCleaner : MonoBehaviour
{

    private float maxLifetime = 5f;

    private void FixedUpdate() {
        maxLifetime -= Time.deltaTime;
        if (maxLifetime <= 0f) {
            Destroy(gameObject);
        }
    }
}
