using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [HideInInspector] public Animator anim;
    private Player player;
    public bool isSeen;

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

    // this exists for the animation to run when it's fading away
    public void Die()
    {
       Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // scene 1 is the level (0 is main menu)
            SceneManager.LoadScene(1);
        }
    }
}
