using System;
using UnityEngine;

public class Enemy : Character
{
    private bool isSeen;
    private float baseSpeed;
    private Vector2 moveDirection;
    [SerializeField] private Player player;
    protected override void Awake()
    {
        base.Awake();
        baseSpeed = MoveSpeed;
    }

    private void FixedUpdate()
    {
        ApplyMovement();
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

    protected override void ApplyMovement()
    {
        Vector3.MoveTowards(transform.position, player.transform.position, MoveSpeed*Time.deltaTime);
    }
}
