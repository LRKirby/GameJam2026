using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JumpscareTrigger2D : MonoBehaviour
{
    public GameObject jumpscareImage;
    public AudioClip jumpscareClip;
    public float duration = 0.5f;

    private AudioSource audioSource;
    private bool triggered = false;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
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

        if (jumpscareClip != null)
            audioSource.PlayOneShot(jumpscareClip);

        yield return new WaitForSeconds(duration);

        jumpscareImage.SetActive(false);
    }
}
