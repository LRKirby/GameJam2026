using NUnit.Framework;
using System;
using UnityEngine;

public class EnemyRemover : MonoBehaviour
{
    private int dieHash;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
            dieHash = Animator.StringToHash("Base Layer.Die");
            foreach (Enemy enemy in enemies)
            {

                enemy.anim.Play(dieHash, 0, 0);
            }
            Destroy(gameObject);
        }
    }
}
