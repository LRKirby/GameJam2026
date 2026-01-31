using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Player player;
    public bool isSeen;
    private Animator anim;
    private float lastPos, direction;

    private void Awake()
    {
        player = FindFirstObjectByType<Player>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isSeen)
        {
            direction = transform.position.x - lastPos;
            lastPos = transform.position.x;
            anim.SetBool("Walking", true);
            if (direction < 0)
                anim.SetBool("FacingRight", false);
            else if (direction > 0)
                anim.SetBool("FacingRight", true);
        }
        else
            anim.SetBool("Walking", false);
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
