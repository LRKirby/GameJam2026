using System;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(PlayerInputHandler))]
public class Player : Character
{
    private Rigidbody2D rBody;
    private PlayerInputHandler input;

    void Awake()
    {
        base.Awake();
        rBody = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInputHandler>();
    }

    void FixedUpdate()
    {
        ApplyMovement();
    }

    protected override void ApplyMovement()
    {
        float horizontalVelocity = input.MoveInput.x * MoveSpeed;
        rBody.linearVelocity = new Vector2(horizontalVelocity, rBody.linearVelocity.y);
    }
}

