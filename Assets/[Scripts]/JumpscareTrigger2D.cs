using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JumpscareTrigger2D : MonoBehaviour
{
    public GameObject jumpscareImage;
    public float duration;

    private AudioSource audioSource;
    private bool triggered = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered)
            return;

        if (other.CompareTag("Player"))
        {
            triggered = true;
            StartCoroutine(Jumpscare());
        }
    }

    IEnumerator Jumpscare()
    {
        jumpscareImage.SetActive(true);

        audioSource.PlayOneShot(audioSource.clip);

        yield return new WaitForSeconds(duration);

        audioSource.Stop();

        jumpscareImage.SetActive(false);
    }
}
