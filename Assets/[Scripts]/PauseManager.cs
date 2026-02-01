using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private PlayerInputHandler player;

    public void ResumeGame()
    {
        player.PausePanel.SetActive(false);
        Time.timeScale = 1f;
        player.IsPaused = false;
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
