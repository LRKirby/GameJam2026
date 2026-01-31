using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu, confirm;
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Exit()
    {
        confirm.SetActive(true);
        menu.SetActive(false);
    }
    public void Yes()
    {
        Application.Quit();
    }
    public void No()
    {
        confirm.SetActive(false);
        menu.SetActive(true);
    }
}
