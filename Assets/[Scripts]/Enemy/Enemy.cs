using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Player player;
    public bool isSeen;

    private void Awake()
    {
        player = FindFirstObjectByType<Player>();
    }

    private void FixedUpdate()
    {
        if (!isSeen)
        {
            ApplyMovement();
        }
    }

    void ApplyMovement()
    {
        transform.position =
            Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.fixedDeltaTime);
    }
}
