using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject credits;
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Credits()
    {
        credits.SetActive(true);
    }
    public void CreditsBack()
    {
        credits.SetActive(false);
    }
}
