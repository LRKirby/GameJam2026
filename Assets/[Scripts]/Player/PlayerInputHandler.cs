using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private Vector2 _moveInput;
    private bool _flashlightOn = false;
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
}
