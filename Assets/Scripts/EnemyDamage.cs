using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int healthPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] AudioClip enemyDamageFx;
    [SerializeField] AudioClip enemyDeathFx;

  
    private void OnParticleCollision(GameObject other)
    {
        ProccesDamage();
        if (healthPoints < 1)
        {
            KillEnemy();
        }
    }

    private void ProccesDamage()
    { 
        healthPoints = healthPoints - 1;
        hitParticlePrefab.Play();
        GetComponent<AudioSource>().PlayOneShot(enemyDamageFx);
    }

    private void KillEnemy()
    {
        var enemyDeathParicle = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        enemyDeathParicle.Play();

        float particleDestroyDelay = enemyDeathParicle.main.duration;
        Destroy(enemyDeathParicle.gameObject, particleDestroyDelay);
        AudioSource.PlayClipAtPoint(enemyDeathFx, Camera.main.transform.position );

 
        Destroy(gameObject);
    }



}
