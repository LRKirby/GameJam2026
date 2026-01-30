using System;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(Animator))]
public class Character : MonoBehaviour
{
	[Header("Base Stats")]
    [SerializeField] private int maxHealth;
    [SerializeField] private float moveSpeed;
    private float currentHealth;
    private float maxSpeed;
    private bool isDead;
	SpriteRenderer sr;
	Animator anim;

	protected int MaxHealth {
		get 
        {
			return maxHealth;
		}
		set 
        {
			maxHealth = Math.Abs(value);
		}
	}

	protected float CurrentHealth {
		get 
        {
			return currentHealth;
		}
		set 
        {
			currentHealth = Math.Clamp(value, 0, maxHealth);
		}
	}

	protected float MaxSpeed {
		get  
        {
			return maxSpeed;
		}
		set 
        {
			maxSpeed = Math.Abs(value);
		}
	}

	protected float MoveSpeed {
		get 
        {
			return moveSpeed;
		}
		set 
        {
			moveSpeed = Math.Clamp(value, 0, maxSpeed);
		}

	}

	protected virtual void Awake() {
        Debug.Log("Awake in Character.cs");
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        sr.sortingLayerName = "Characters";
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(float damageToTake)
    {
        // take damage equal to parameter
        CurrentHealth -= damageToTake;

		// check if dead
        if (currentHealth <= 0 && !isDead)
        {
			Debug.Log($"{gameObject.name} is dead.");
			Die();
        }
    }

    protected virtual void Die()
    {
        isDead = true;
    }

    protected virtual void ApplyMovement()
    {

    }
}
