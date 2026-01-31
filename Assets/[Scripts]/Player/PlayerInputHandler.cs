using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms;

public class PlayerInputHandler : MonoBehaviour
{
    private Vector2 _moveInput;
    private bool _flashlightOn, isClose, open;
    private Drawer drawer;
    public Vector2 MoveInput
    {
        get { return _moveInput; }
    }

    public bool FlashlightOn
    {
        get { return _flashlightOn; }
        set { _flashlightOn = value; }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        FlashlightOn = !FlashlightOn;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        drawer = other.gameObject.GetComponent<Drawer>();
        if (drawer != null)
        {
            isClose = true;
            Debug.Log("AA");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (drawer != null)
        {
            isClose = false;
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
