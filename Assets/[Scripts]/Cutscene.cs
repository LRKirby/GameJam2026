using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    [SerializeField] private PlayableDirector cutsceneDirector;
    private bool hasPlayed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasPlayed)
        {
            other.gameObject.SetActive(false);
            cutsceneDirector.gameObject.SetActive(true);
            cutsceneDirector.Play();
            hasPlayed = true;
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(20);
        SceneManager.LoadScene(0);
    }
}
