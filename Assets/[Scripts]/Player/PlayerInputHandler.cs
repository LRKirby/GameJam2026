using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms;
using static UnityEngine.Timeline.DirectorControlPlayable;

public class PlayerInputHandler : MonoBehaviour
{
    private Vector2 _moveInput;
    private bool _flashlightOn, isClose, open;
    public InputAction PauseAction; // This too
    private Drawer drawer;
    [SerializeField] private AudioClip onSound, offSound;
    [SerializeField] private AudioSource sound;

    private void OnEnable() // I added this I dont think its needs 
    {
        if (PauseAction != null)
            PauseAction.Enable();
    }

    private void OnDisable()
    {
        if (PauseAction != null)
            PauseAction.Disable();
    }

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
        get { return open; }
        set { open = value; }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (!open)
        {
            if (!FlashlightOn)
                sound.PlayOneShot(onSound);
            else
                sound.PlayOneShot(offSound);
            FlashlightOn = !FlashlightOn;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        drawer = other.gameObject.GetComponent<Drawer>();
        if (drawer != null)
            isClose = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (drawer != null)
        {
            isClose = false;
            drawer = null;
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
