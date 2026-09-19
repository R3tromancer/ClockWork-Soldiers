using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;

    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem projectileParticle;

    public Waypoint baseWaypoint;

    Transform targetEnemy;

    void Update()
    {
        SetTargetEnemy();


        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }

    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach(EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosestEnemy(closestEnemy, testEnemy.transform);
        }

        targetEnemy = closestEnemy;
    }

    private Transform GetClosestEnemy(Transform TransformA, Transform TransformB)
    {
        float enemyADistance = Vector3.Distance(TransformA.position, gameObject.transform.position);
        float enemyBDistance = Vector3.Distance(TransformB.position, gameObject.transform.position);
        if (enemyADistance < enemyBDistance)
        {
            return TransformA;
        }
        else
        {
            return TransformB;
        }
    }

    private void FireAtEnemy()
    {
        float distance =  Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if (distance <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);

        }

    }

    private void Shoot ( bool isActive)
    {
       var emmisionModule = projectileParticle.emission;
       emmisionModule.enabled = isActive;
    }


}
