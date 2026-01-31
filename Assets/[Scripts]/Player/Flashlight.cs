using UnityEngine;
using UnityEngine.InputSystem;


//attach to player
public class Flashlight : MonoBehaviour {
    [SerializeField] private Camera playerCamera; // reference the camera
    private Vector2 direction, controllerAim; // some vectors for where the weapon will rotate
    public Vector2 localMouse; // this needs to be public for the player animations
    private Vector3 globalMouse; // needs a z axis for rotation
    private float angle;
    private bool usingController;

    private float screenX, screenY;

    private void Start() {
        screenX = Screen.width / 2;
        screenY = Screen.height / 2;
    }

    private void FixedUpdate() {
        // check if controller is disconnected
        if (Gamepad.current != null) {
            usingController = true;
        } else {
            usingController = false;
        }

        // controller aiming
        if (usingController) {
            controllerAim = Gamepad.current.rightStick.ReadValue(); // get the joystick position

            if (controllerAim.magnitude < 0.2f) // deadzone
            {
                Mouse.current.WarpCursorPosition(new Vector2(screenX, screenY));
                return;
            }
            angle = Mathf.Atan2(controllerAim.y, controllerAim.x) * Mathf.Rad2Deg; // find the angle with mathf
            transform.rotation = Quaternion.Euler(0, 0, angle); // quatertion euler for the rotation of the weapon
                                                                // gamepad mouse cursor
            Mouse.current.WarpCursorPosition(new Vector2((controllerAim.x + 1) * screenX, (controllerAim.y + 1) * screenY));
        }

        // mouse aiming
        else {
            localMouse = Mouse.current.position.ReadValue(); // get the mouse position

            globalMouse = playerCamera.ScreenToWorldPoint(localMouse); // get the mouse position relative to the screen

            direction = globalMouse - transform.position;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // documentation said we need this for the angle
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle)); // it also said this for the rotation
        }
    }
}


