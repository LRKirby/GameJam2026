using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private Vector2 _moveInput;
    public Vector2 MoveInput
    {
        get { return _moveInput; }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
        Debug.Log($"{_moveInput}");
    }
}
