using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    private bool isPaused = false;
    private PlayerInputHandler playerInput;

    private void Awake()
    {
        playerInput = FindFirstObjectByType<PlayerInputHandler>();
        if (pausePanel != null)
            pausePanel.SetActive(false);
    }

    private void OnEnable()
    {
        if (playerInput != null && playerInput.PauseAction != null)
            playerInput.PauseAction.performed += OnPause;
    }

    private void OnDisable()
    {
        if (playerInput != null && playerInput.PauseAction != null)
            playerInput.PauseAction.performed -= OnPause;
    }

    private void OnPause(InputAction.CallbackContext context)
    {
        if (isPaused)
            ResumeGame();
        else
            PauseGame();
    }

    public void PauseGame()
    {
        if (pausePanel != null)
            pausePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        if (pausePanel != null)
            pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
