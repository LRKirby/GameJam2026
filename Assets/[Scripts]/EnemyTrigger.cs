using System;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnemyTrigger : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private List<GameObject> enemySpawnLocation;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < enemySpawnLocation.Count; i++)
            {
                Debug.Log("Spawning enemies");
                SpawnEnemy(enemySpawnLocation[i].transform.position);
            }
            Destroy(gameObject);
        }
    } 

    void SpawnEnemy(Vector2 spawnLocation)
    {
        Instantiate(enemyPrefab, spawnLocation, Quaternion.identity);
    }

}
