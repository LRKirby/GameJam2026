using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private Vector2 _moveInput;
    private bool _flashlightOn, isClose, open, isPaused;
    private Drawer drawer;
    [SerializeField] private AudioClip onSound, offSound;
    [SerializeField] private AudioSource sound;
    [SerializeField] private GameObject pausePanel;

    public Vector2 MoveInput
    {
        get { return _moveInput; }
    }
    
    public bool FlashlightOn
    {
        get { return _flashlightOn; }
        set { _flashlightOn = value; }
    }

    public bool Open
    {
        set { open = value; }
    }

    public bool IsPaused
    {
        set { isPaused = value; }
    }

    public GameObject PausePanel
    {
        get { return pausePanel; }
        set { pausePanel = value; }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (!open && !isPaused)
        {
            if (!FlashlightOn)
                sound.PlayOneShot(onSound);
            else
                sound.PlayOneShot(offSound);
            FlashlightOn = !FlashlightOn;
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        if (!isPaused)
        {
            if (!open)
            {
                pausePanel.SetActive(true);
                Time.timeScale = 0;
                isPaused = true;
            }
            else
            {
                Time.timeScale = 1;
                drawer.GetDrawer.SetActive(false);
                open = false;
                
            }
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Drawer"))
        {
            drawer = other.gameObject.GetComponent<Drawer>();
            if (drawer != null)
            {
                drawer.Text.SetActive(true);
                isClose = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Drawer"))
        {
            if (drawer != null)
            {
                drawer.Text.SetActive(false);
                isClose = false;
            }
        }
    }

    public void OnInteract(InputAction.CallbackContext action)
    {
        if (isClose)
        {
            if (!open)
            {
                Time.timeScale = 0;
                drawer.GetDrawer.SetActive(true);
                open = true;
            }
            else
            {
                Time.timeScale = 1;
                drawer.GetDrawer.SetActive(false);
                open = false;
            }
        }
    }
}
