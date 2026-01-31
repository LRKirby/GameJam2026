using System;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(PlayerInputHandler))]
public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rBody;
    private PlayerInputHandler input;
    private float xVelocity;
    private float yVelocity;

    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInputHandler>();
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

