using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{

    [SerializeField] float periodBetweenMoves;
    [SerializeField] ParticleSystem goalExplosion;

    
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    
    IEnumerator FollowPath(List<Waypoint> path)
    {
        print("Starting patrol...");
        foreach (Waypoint waypoint in path )
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(periodBetweenMoves);
        }

        SelfDestruct();

    }

    private void SelfDestruct()
    {
        var goalVfx = Instantiate(goalExplosion, transform.position, Quaternion.identity);
        goalVfx.Play();

        Destroy(goalVfx.gameObject, 1);
        Destroy(gameObject);
    }


}
