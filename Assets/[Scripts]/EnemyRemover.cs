using System;
using UnityEngine;

public class EnemyRemover : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
            foreach (Enemy enemy in enemies)
            {
                Destroy(enemy.gameObject);
            }
            Destroy(gameObject);
        }
    }
}
