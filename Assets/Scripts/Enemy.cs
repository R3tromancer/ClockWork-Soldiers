using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int hitPoints = 10;
    [SerializeField] GameObject enemyDeathFX;
    [SerializeField] Transform recycleBin;

    void OnParticleCollision(GameObject other)
    {
        hitPoints--;
        if (hitPoints < 1)
        {
            DeathSequence();
        }
    }

    private void DeathSequence()
    {
        GameObject fx = Instantiate(enemyDeathFX, transform.position, Quaternion.identity);
        fx.transform.parent = recycleBin;
        Destroy(gameObject);
    }


 
}
