using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 10f)]
    [SerializeField] float secondsBetweenSpawn;
    [SerializeField] GameObject enemiesToSpawn;
    [SerializeField] Transform enemyPlaceholder;
    [SerializeField] Text enemyCount;
    [SerializeField] AudioClip enemySpawnClip;

    int enemyNum;
    int infiniteCounter = 50;

    void Start()
    {
        enemyCount.text = enemyNum.ToString();
        StartCoroutine(SpawnEnemies());

    }

    IEnumerator SpawnEnemies()
    {

        while (infiniteCounter > 0)
        {
            infiniteCounter = infiniteCounter - 1;
            yield return new WaitForSeconds(secondsBetweenSpawn);

            var newEnemy = Instantiate(enemiesToSpawn, transform.position, Quaternion.identity);
            GetComponent<AudioSource>().PlayOneShot(enemySpawnClip);
            newEnemy.transform.parent = enemyPlaceholder;
            AddScore();

        }
        

//
    }

    private void AddScore()
    {
        enemyNum++;
        enemyCount.text = enemyNum.ToString();
    }
}
