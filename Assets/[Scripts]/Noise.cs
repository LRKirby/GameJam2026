using UnityEngine;

public class Noise : MonoBehaviour
{
    private AudioSource noise;

    private void Awake()
    {
        noise = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            noise.PlayOneShot(noise.clip);
        }
    }
}
