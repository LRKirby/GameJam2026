using UnityEngine;

public class FlashlightDetection : MonoBehaviour
{
    private Enemy enemy;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemy = other.GetComponent<Enemy>();
            enemy.isSeen = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemy = other.GetComponent<Enemy>();
            enemy.isSeen = false;
        }
    }
}
