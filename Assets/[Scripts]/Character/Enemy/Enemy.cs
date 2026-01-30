using System;
using UnityEngine;

public class Enemy : Character
{
    private bool isSeen;
    private float baseSpeed;
    private Vector2 moveDirection;
    [SerializeField] private PlayerController player;
    protected override void Awake()
    {
        base.Awake();
        baseSpeed = MoveSpeed;
    }

    private void FixedUpdate()
    {
        UpdateMovement();
    }

    void Update()
    {
        if (isSeen)
        {
            MoveSpeed = 0;
        }
        else
        {
            MoveSpeed = baseSpeed;
        }
    }

    public bool IsSeen
    {
        get
        {
            return isSeen;
        }
        set
        {
            isSeen = value;
        }
    }

    private void UpdateMovement()
    {
        Vector3.MoveTowards(transform.position, player.transform.position, MoveSpeed*Time.deltaTime);
    }
}
