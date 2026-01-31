using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(PlayerInputHandler))]
public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject lightObj;
    private Rigidbody2D rBody;
    private PlayerInputHandler input;
    private float xVelocity;
    private float yVelocity;
    private Animator anim;
    private Vector2 mouse, lightRotation;

    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInputHandler>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (rBody.linearVelocity.x != 0 || rBody.linearVelocity.y != 0)
            anim.SetBool("Walking", true);
        else
            anim.SetBool("Walking", false);

        // get the mouse location on the screen
        mouse = Mouse.current.position.ReadValue();
        // find the middle of the screen
        // if the mouse is on the left, turn left
        if (mouse.x < Screen.width / 2)
        {
            LightFlip();
            anim.SetBool("FacingRight", false);
        }
        // if the mouse is on the right, turn right
        if (mouse.x > Screen.width / 2)
        {
            LightFlip();
            anim.SetBool("FacingRight", true);
        }
    }

    private void LightFlip()
    {
        lightRotation = lightObj.transform.localScale;
        if (anim.GetBool("FacingRight"))
            lightRotation.y = 1;
        else
            lightRotation.y = -1;
        lightObj.transform.localScale = lightRotation;
    }

    void FixedUpdate()
    {
        ApplyMovement();
    }

    void ApplyMovement()
    {
        xVelocity = input.MoveInput.x * moveSpeed;
        yVelocity = input.MoveInput.y * moveSpeed;
        rBody.linearVelocity = new Vector2(xVelocity, yVelocity);
    }
}

