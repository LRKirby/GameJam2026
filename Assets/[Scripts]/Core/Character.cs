using System;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(Animator))]
public class Character : MonoBehaviour
{
	private int maxHealth;
	private int currentHealth;
	private float moveSpeed;
	private float maxSpeed;
	SpriteRenderer sr;
	Animator anim;

	protected int MaxHealth {
		get {
			return maxHealth;
		}
		set {
			maxHealth = Math.Abs(value);
		}
	}

	protected int CurrentHealth {
		get {
			return currentHealth;
		}
		set {
			currentHealth = Math.Clamp(value, 0, maxHealth);
		}
	}

	protected float MaxSpeed {
		get  {
			return maxSpeed;
		}
		set {
			maxSpeed = Math.Abs(value);
		}
	}

	protected float MoveSpeed {
		get {
			return moveSpeed;
		}
		set {
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
}
