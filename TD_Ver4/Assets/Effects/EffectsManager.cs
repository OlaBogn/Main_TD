using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    public static EffectsManager effectsManager;

    public GameObject[] explosionEffects;
    public GameObject[] deathEffects;
    
    public void SpawnExplosionEffect(int n, Transform trans) {
        Instantiate(explosionEffects[n], trans.position, Quaternion.identity);
    }

    public void SpawnDeathEffect(int n, Transform trans) {
        Instantiate(deathEffects[n], trans.position, Quaternion.identity);
    }
    
}
