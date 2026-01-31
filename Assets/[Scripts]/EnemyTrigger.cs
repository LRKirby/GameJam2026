using System;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private List<GameObject> enemyList;
    private List<GameObject> spawnedEnemies;

    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach (GameObject enemy in enemyList)
        {
            spawnedEnemies.Add(SpawnEnemy());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        foreach (GameObject enemy in spawnedEnemies)
        {
            Destroy(enemy);
        }
    }

    GameObject SpawnEnemy()
    {
        GameObject spawnedEnemy = Instantiate(enemyPrefab, new Vector2(0, 0), Quaternion.identity);
        return spawnedEnemy;
    }

}
